using Application.Interfaces;
using AutoMapper;
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
            private readonly IMapper _imapper;
            private readonly ISoftParkDbContext<Customer> _softParkDbContext;

            public GetCustomersHandler(IMongoClient database,ISoftParkDbContext<Customer> softParkDbContext,IMapper imapper)
            {
                _database=database.GetDatabase(Constants.DatabaseName);
                _softParkDbContext=softParkDbContext;
                _imapper = imapper;
            }
            
            public async Task<IList<Customer>> Handle(GetCustomersQuerie request, CancellationToken cancellationToken)
            {
                
                var collection = _database.GetCollection<Customer>(Constants.CustomerCollectionName);
                var v= await collection.Find(new BsonDocument()).ToListAsync(cancellationToken);
                var customers=_imapper.Map<IList<Customer>>(v);
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
