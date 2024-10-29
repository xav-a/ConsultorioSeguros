using ConsultorioSeguros.Server.Entities;

namespace ConsultorioSeguros.Server.Interfaces
{
    public interface IClientRepository : IRepository<int, Client>
    {
        Task<int> BulkAdd(IEnumerable<Client> clients);

        Task<Client> GetByIdNumber(string identificationNumber);
    }
}