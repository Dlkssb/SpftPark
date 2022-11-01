using Domain.Entities;


namespace Application.Interfaces
    
{
    public interface ISoftParkDbContext<T> where T : EntityBase
    {

     public  Task<IList<T>> GetAll(CancellationToken cancellationToken);

      public  Task<T> FindByIdAsync(Guid id,CancellationToken cancellationToken);

       public  Task<Guid> InsertOneAsync(T document, CancellationToken cancellationToken);

      public  Task<Guid> ReplaceOneAsync(T document,CancellationToken cancellationToken);

      public  Task DeleteByIdAsync(Guid id,CancellationToken cancellationToken);

        
    }
}
