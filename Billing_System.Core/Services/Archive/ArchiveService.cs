namespace Billing_System.Core.Services.Archive
{
    using Billing_System.Core.Contracts.Archive;
    using Billing_System.Core.ViewModels.ArchiveClients;
    using Billing_System.Data;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    public class ArchiveService : IArchiveService
    {
        private readonly BillingDbContext _dbContext;

        public ArchiveService(BillingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task ArchiveClients(int month)
        {
            int[] months = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            if (!months.Contains(month))
            {
                throw new DbUpdateException("Invalid month");
            }

            string monthName = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(month);
            string tableClientsName = $"Clients_{monthName}";
            string tablePaymentsName = $"Payments_{monthName}";
            string tableExpensesName = $"Expenses_{monthName}";
            string tableTechnicalProblemsName = $"TechnicalProblems_{monthName}";

            var sql = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableClientsName}'";
            var sqlConnection = _dbContext.Database.GetDbConnection();
            await sqlConnection.OpenAsync();
            var command = sqlConnection.CreateCommand();
            command.CommandText = sql;
            var result = await command.ExecuteScalarAsync();

            if (result != null && (int)result > 0)
            {
                await sqlConnection.CloseAsync();
                throw new DbUpdateException("Archive already exists");
            }
            await sqlConnection.CloseAsync();


            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Database.ExecuteSqlRawAsync(
                        $"SELECT c.* INTO {tableClientsName} FROM Clients AS c  LEFT JOIN Payments AS p ON c.Id = p.ClientId WHERE p.Pending = 0"
                        );

                    await _dbContext.Database.ExecuteSqlRawAsync($"SELECT * INTO {tablePaymentsName} FROM Payments WHERE Payments.Pending = 0");
                    await _dbContext.Database.ExecuteSqlRawAsync($"SELECT * INTO {tableExpensesName} FROM Expenses");
                    await _dbContext.Database.ExecuteSqlRawAsync($"SELECT * INTO {tableTechnicalProblemsName} FROM TechnicalProblems");
                  

                    var payments = await _dbContext
                        .Payments
                        .Where(p => p.Pending == false)
                        .ToListAsync();
                    _dbContext.Payments.RemoveRange(payments);
                    await _dbContext.SaveChangesAsync();


                    var clients = await _dbContext
                        .Clients
                        .Include(c => c.Payments)
                        .Where(c => !c.Payments.Any())
                        .ToListAsync();

                    _dbContext.Clients.RemoveRange(clients);
                    await _dbContext.SaveChangesAsync();

                    await _dbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE Expenses");
                    await _dbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE TechnicalProblems");

                    await transaction.CommitAsync();
                }
                catch (DbUpdateException)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

        }

        public async Task<ICollection<ArchiveMonthDetails>> GetMonthDetailsAsync()
        {
            ICollection<ArchiveMonthDetails> archiveMonthsDetails = new List<ArchiveMonthDetails>();
            for (int i = 1; i <= 12; i++)
            {
                var monthName = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(i);

                var sql = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Clients_{monthName}'";
                var sqlConnection = _dbContext.Database.GetDbConnection();
                await sqlConnection.OpenAsync();
                var command = sqlConnection.CreateCommand();
                command.CommandText = sql;
                var result = await command.ExecuteScalarAsync();

                if (result == null || (int)result == 0)
                {
                    await sqlConnection.CloseAsync();
                    continue;
                }


                var clientsCount = _dbContext.Clients.FromSqlRaw($"SELECT * FROM Clients_{monthName}").Count();
                var totalAmount = _dbContext.Payments.FromSqlRaw($"SELECT * FROM Payments_{monthName}").Sum(p => p.Fee);
                var totalExpenses = _dbContext.Expenses.FromSqlRaw($"SELECT * FROM Expenses_{monthName}").Sum(e => e.Value);
                var totalTechnicalProblems = _dbContext.TechnicalProblems.FromSqlRaw($"SELECT * FROM TechnicalProblems_{monthName}").Count();
                var archiveMonthDetails = new ArchiveMonthDetails
                {
                    MonthName = monthName,
                    ClientsCount = clientsCount,
                    TotalAmount = totalAmount,
                    TotalExpenses = totalExpenses,
                    TotalTechnicalProblems = totalTechnicalProblems
                };
                archiveMonthsDetails.Add(archiveMonthDetails);
                await sqlConnection.CloseAsync();
            }
            return archiveMonthsDetails;

        }

        public async Task DeleteMonth(string monthName)
        {
            string[] months = CultureInfo.InvariantCulture.DateTimeFormat.MonthNames;
            if (!months.Contains(monthName))
            {
                throw new DbUpdateException("Invalid month");
            }
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Database.ExecuteSqlRawAsync($"DROP TABLE IF EXISTS Clients_{monthName};");
                    await _dbContext.Database.ExecuteSqlRawAsync($"DROP TABLE IF EXISTS Payments_{monthName};");
                    await _dbContext.Database.ExecuteSqlRawAsync($"DROP TABLE IF EXISTS Expenses_{monthName};");
                    await _dbContext.Database.ExecuteSqlRawAsync($"DROP TABLE IF EXISTS TechnicalProblems_{monthName};");
                    await transaction.CommitAsync();
                }
                catch (OperationCanceledException)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

    }
}
