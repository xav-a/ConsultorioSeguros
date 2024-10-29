namespace ConsultorioSeguros.Server.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        Task<T> Get(K id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<IEnumerable<T>> GetAll();
    }
}