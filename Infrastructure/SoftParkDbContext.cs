using Application;
using Application.Interfaces;
using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;



namespace Infrastructure
{
    public class SoftParkDbContext<T> : ISoftParkDbContext<T> where T : EntityBase
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<T>  _Collection;

        public SoftParkDbContext(IMongoClient database)
        {
            _database = database.GetDatabase(Constants.GetDatabaseName());
            _Collection = _database.GetCollection<T>("");
        }

        public Task DeleteByIdAsync(Guid id,CancellationToken cancellationToken)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(enitiy => enitiy.Id, id);
            var customer =  _Collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
            _Collection.DeleteOneAsync(filter);
            return Task.CompletedTask;
        }

        public async Task<T> FindByIdAsync(Guid id,CancellationToken cancellationToken)
        {
            var filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
            var customer = await _Collection.FindAsync<T>(filter);

            return customer.First();
        }

        public async Task<IList<T>> GetAll(CancellationToken cancellationToken)
        {
            var listEntity= await _Collection.Find(new BsonDocument()).ToListAsync(cancellationToken);
            return listEntity;
        }

        public async Task<Guid> InsertOneAsync(T document,CancellationToken cancellationToken)
        {
            await _Collection.InsertOneAsync(document,null,cancellationToken);
            return document.Id;
        }

        public async Task<Guid> ReplaceOneAsync(T document,CancellationToken cancellationToken)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(doc => doc.Id, document.Id);
           var r= await _Collection.ReplaceOneAsync(filter, document, new UpdateOptions { IsUpsert = true }, cancellationToken);
            return document.Id;
        }


       
    }
}
