using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Application.Interfaces
    
{
    public interface ISoftParkDbContext<T> : IMongoDatabase where T : class
    {

     public   IQueryable<T> AsQueryable();

      public  IEnumerable<T> FilterBy(
            Expression<Func<T, bool>> filterExpression);

       public IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, TProjected>> projectionExpression);

        T FindOne(Expression<Func<T, bool>> filterExpression);

       public Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression);

        T FindById(Guid id);

        Task<T> FindByIdAsync(Guid id);

        void InsertOne(T document);

        Task<Guid> InsertOneAsync(T document);

        void InsertMany(ICollection<T> documents);

        Task InsertManyAsync(ICollection<T> documents);

        void ReplaceOne(T document);

        Task<Guid> ReplaceOneAsync(T document);

        void DeleteOne(Expression<Func<T, bool>> filterExpression);

        Task DeleteOneAsync(Expression<Func<T, bool>> filterExpression);

        void DeleteById(Guid id);

        Task DeleteByIdAsync(Guid id);

        void DeleteMany(Expression<Func<T, bool>> filterExpression);

        Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression);



        Task<Guid> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
