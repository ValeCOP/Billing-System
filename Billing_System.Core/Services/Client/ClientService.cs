namespace Billing_System.Core.Services.Clients
{
    using Billing_System.Core.Contracts.Clients;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Core.ViewModels.Payments;
    using Billing_System.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class ClientService : IClientsService
    {
        private readonly BillingDbContext _context;
        public ClientService(BillingDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ActivatedClientsViewModel>> GetAllClientsAsync(string orderBy, string searchString)
        {
            var clients = _context.Clients
                .Include(c => c.Payments)
                .AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(c => c.FullName.ToLower().Contains(searchString.ToLower()));
            }
            switch (orderBy)
            {
                case "FullName":
                    {
                        clients = clients.OrderBy(c => c.FullName);
                        break;
                    }
                case "FullNameDesc":
                    {
                        clients = clients.OrderByDescending(c => c.FullName);
                        break;
                    }


                case "ActivationDate":
                    {
                        clients = clients.OrderBy(c => c.ActivationDate);
                        break;
                    }
                case "ActivationDateDesc":
                    {
                        clients = clients.OrderByDescending(c => c.ActivationDate);
                        break;
                    }

                case "ExpiredDate":
                    {
                        clients = clients.OrderBy(c => c.ExpiredDate);
                        break;
                    }
                case "ExpiredDateDesc":
                    {
                        clients = clients.OrderByDescending(c => c.ExpiredDate);
                        break;
                    }

                case "ApplicationUser":
                    {
                        clients = clients.OrderBy(c => c.ApplicationUser.UserName);
                        break;
                    }
                case "ApplicationUserDesk":
                    {
                        clients = clients.OrderByDescending(c => c.ApplicationUser.UserName);
                        break;
                    }


                default:
                    {
                        clients = clients.OrderByDescending(c => c.ActivationDate);
                        break;
                    }
            }

            var model = await clients.Select(c => new ActivatedClientsViewModel
            {
                ClientId = c.Id,
                FullName = c.FullName,
                ActivationDate = c.ActivationDate.ToString("yyyy-MM-dd hh:mm:ss"),
                ExpiredDate = c.ExpiredDate.ToString("yyyy-MM-dd"),
                Comments = c.Comments,
                Address = c.Address,
                ApplicationUser = c.ApplicationUser.UserName,
                Payments = c.Payments.Select(p => new PaymentsDetailsView
                {
                    Pending = p.Pending
                }).ToList(),

            }).ToListAsync();
            return model;

        }

        public async Task<ActivatedClientsViewModel> GetClientDetailsAsync(Guid id)
        {
            var client = await _context.Clients
                .Include(c => c.ApplicationUser)
                .Include(c => c.Payments)
                .FirstOrDefaultAsync(c => c.Id == id);

            var model = new ActivatedClientsViewModel
            {
                ClientId = client!.Id,
                FullName = client.FullName,
                ActivationDate = client.ActivationDate.ToString("yyyy-MM-dd hh:mm:ss"),
                ExpiredDate = client.ExpiredDate.ToString("yyyy-MM-dd"),
                Comments = client.Comments,
                Address = client.Address,
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
                    FromDate = p.FromDate.ToString("yyyy-MM-dd hh:mm:ss"),
                    ToDate = p.ToDate.ToString("yyyy-MM-dd"),
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
                                   ActivationDate = c.ActivationDate.ToString("yyyy-MM-dd hh:mm:ss"),
                                   ExpiredDate = c.ExpiredDate.ToString("yyyy-MM-dd"),
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

        public async Task<int> GetTotalPages(int pageSize)
        {
            var data =  (int)Math.Ceiling( (double) await _context.Clients.CountAsync() / pageSize);
            return data;
        }
    }
}
