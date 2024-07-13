namespace Billing_System.Core.Services.Clients
{
    using Billing_System.Core.Contracts.Clients;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Core.ViewModels.Payments;
    using Billing_System.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants;

    public class ClientService : IClientsService
    {
        private readonly BillingDbContext _context;
        public ClientService(BillingDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ActivatedClientsViewModel>> GetAllClientsAsync(FilteredClientsViewModel model)
        {
            var clients = _context.Clients
                .Include(c => c.Payments)
                .OrderByDescending(c => c.ActivationDate)
                .AsQueryable();

            if (!string.IsNullOrEmpty(model.Filter))
            {
                clients = clients.Where(c => c.FullName.ToLower().Contains(model.Filter.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.OrderBy))
            {
                clients = model.OrderBy switch
                {
                    "FullName" => clients.OrderBy(c => c.FullName),
                    "FullNameDesc" => clients.OrderByDescending(c => c.FullName),
                    "ActivationDate" => clients.OrderBy(c => c.ActivationDate),
                    "ActivationDateDesc" => clients.OrderByDescending(c => c.ActivationDate),
                    "ExpiredDate" => clients.OrderBy(c => c.ExpiredDate),
                    "ExpiredDateDesc" => clients.OrderByDescending(c => c.ExpiredDate),
                    "ApplicationUser" => clients.OrderBy(c => c.ApplicationUser.UserName),
                    "ApplicationUserDesc" => clients.OrderByDescending(c => c.ApplicationUser.UserName),
                    _ => clients.OrderByDescending(c => c.ActivationDate),
                };
            }
            if (model.Pending)
            {
                clients = clients.Where(c => c.Payments.Any(p => p.Pending));
            }

            clients = clients.Skip((model.CurrentPage - 1) * 8).Take(8);
            model.ClientsCount = await clients.CountAsync();

            var allClients = await clients.Select(c => new ActivatedClientsViewModel
            {
                ClientId = c.Id,
                FullName = c.FullName,
                ActivationDate = c.ActivationDate.ToString(AppActivationDateFormatForDb),
                ExpiredDate = c.ExpiredDate.ToString(AppExpiredDateFormat),
                Comments = c.Comments,
                Address = c.Address,
                ApplicationUser = c.ApplicationUser.UserName,
                Payments = c.Payments.Select(p => new PaymentsDetailsView
                {
                    Pending = p.Pending
                }).ToList(),

            }).ToListAsync();
            return allClients;

        }

        public async Task<ActivatedClientsViewModel> GetClientDetailsAsync(Guid id)
        {
            var client = await _context.Clients
                .Include(c => c.ApplicationUser)
                .Include(c => c.Payments)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                throw new ArgumentNullException("Client not found");
            }

            var model = new ActivatedClientsViewModel
            {
                ClientId = client!.Id,
                FullName = client.FullName,
                ActivationDate = client.ActivationDate.ToString(AppActivationDateFormatForDb),
                ExpiredDate = client.ExpiredDate.ToString(AppExpiredDateFormat),
                Comments = client.Comments,
                Address = client.Address,
                Email = client.Email,
                Phone = client.Phone,
                ApplicationUser = client.ApplicationUser.UserName,
            };

            var payments = await _context.Payments
                .Where(p => p.ClientId == id)
                .OrderByDescending(p => p.FromDate)
                .Select(p => new PaymentsDetailsView
                {
                    Id = p.Id,
                    Name = p.Name,
                    Value = p.Fee,
                    InstallationFee = p.InstallationFee,
                    Pending = p.Pending,
                    Receipt = p.Receipt,
                    FromDate = p.FromDate.ToString(AppActivationDateFormatForDb),
                    ToDate = p.ToDate.ToString(AppExpiredDateFormat),
                    ApplicationUser = p.ApplicationUser.UserName,
                    ClientId = p.ClientId,
                }).ToListAsync();
            model.Payments = payments;

            return model;
        }

        public async Task<ICollection<ShortInfoForActivatedClients>> GetClientShortAsync()
        {
            var clients = await _context.Clients
                .Include(c => c.Payments)
                               .Select(c => new ShortInfoForActivatedClients
                               {
                                   ClientId = c.Id,
                                   FullName = c.FullName,
                                   ActivationDate = c.ActivationDate.ToString(AppActivationDateFormatForDb),
                                   ExpiredDate = c.ExpiredDate.ToString(AppExpiredDateFormat),
                                   Pending = c.Payments.Any(p => p.Pending)
                               }).ToListAsync();
            return clients;
        }

        public async Task DeleteClientAsync(Guid id)
        {
            var client = await _context.Clients
                .Include(c => c.Payments)
                .FirstOrDefaultAsync(c => c.Id == id);
            _context.Payments.RemoveRange(client!.Payments);
            _context.Clients.Remove(client!);
            _context.SaveChanges();
        }

    }
}
