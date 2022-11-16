using UI.Models;

namespace UI.Interfaces
{
    public interface IServicesBase<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsync(Guid Id);

        public Task Edit(T entity);
        public Task Delete(Guid Id);

        public Task<Guid> Create(T entity);

        
    }
}
