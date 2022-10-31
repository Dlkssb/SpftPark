using Application;
using Application.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure
{
    public class SoftParkDbContext<T> : ISoftParkDbContext<T> where T : class
    {
        private readonly IMongoDatabase _database;

        public SoftParkDbContext(IMongoClient database)
        {
            _database = database.GetDatabase(Constants.GetDatabaseName());
        }

        public IQueryable<T> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteMany(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public void DeleteOne(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FilterBy(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, TProjected>> projectionExpression)
        {
            throw new NotImplementedException();
        }

        public T FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public T FindOne(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public void InsertMany(ICollection<T> documents)
        {
            throw new NotImplementedException();
        }

        public Task InsertManyAsync(ICollection<T> documents)
        {
            throw new NotImplementedException();
        }

        public void InsertOne(T document)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertOneAsync(T document)
        {
            throw new NotImplementedException();
        }

        public void ReplaceOne(T document)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> ReplaceOneAsync(T document)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
