
using ConsultorioSeguros.Server.Entities;
using ConsultorioSeguros.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioSeguros.Server.Data.Repository
{
    public class ClientRepository : Repository<int, Client>, IClientRepository
    {
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(
            ILogger<ClientRepository> logger,
            AppDbContext context) : base(context)
        {
            _logger = logger;
        }

        public async Task<int> BulkAdd(IEnumerable<Client> clients)
        {
            try
            {
                var dbSet = _context.Set<Client>();
                dbSet.AddRange(clients);

                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Failed to mass insert {clients.Count()} entries for {nameof(Client)}");
                return -1;
            }
        }

        public Task<Client> GetByIdNumber(string identificationNumber)
        {
            return _context
                .Set<Client>()
                .Include(c => c.InsurancePlans)
                .FirstOrDefaultAsync(c => c.IdentificationNumber == identificationNumber);
        }
    }
}
