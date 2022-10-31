using Domain.Entities;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Queries
{
    public class GetCustomersQuerie : IRequest<IList<Customer>>
    {
        public class GetCustomersHandler : IRequestHandler<GetCustomersQuerie, IList<Customer>>
        {
            
           private readonly IMongoDatabase _database;

            public GetCustomersHandler(IMongoClient database)
            {
                _database=database.GetDatabase(Constants.DatabaseName);
            }
            
            public async Task<IList<Customer>> Handle(GetCustomersQuerie request, CancellationToken cancellationToken)
            {
                var collection = _database.GetCollection<Customer>(Constants.CategoriesCollectionName);
                var customers= await collection.Find(new BsonDocument()).ToListAsync(cancellationToken);
                try
                {
                    return customers;
                }

                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
                
            }
        }
    }
}
