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
    public interface ISoftParkDbContext<T> where T : class
    {

     public   IQueryable<T> AsQueryable();

      public  IEnumerable<T> FilterBy(
            Expression<Func<T, bool>> filterExpression);

       public IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, TProjected>> projectionExpression);


        Task<T> FindByIdAsync(Guid id);

        Task<Guid> InsertOneAsync(T document);

        Task<Guid> ReplaceOneAsync(T document);

        Task DeleteByIdAsync(Guid id);

        Task<Guid> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
