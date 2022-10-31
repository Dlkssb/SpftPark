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
    public class GetCustomerQuerie : IRequest<Customer>
    {
        public Guid? CustomerId { get; set; }

        public class GetCustomerHandler : IRequestHandler<GetCustomerQuerie, Customer>
        {
           
            private readonly IMongoDatabase _database;
            private readonly IMapper _mapper;
            private readonly ISoftParkDbContext<Customer> _softParkDbContexe;
            public GetCustomerHandler(IMongoClient database, IMapper mapper, ISoftParkDbContext<Customer> softParkDbContexe)
            {
                _database=database.GetDatabase(Constants.GetDatabaseName());
                _mapper=mapper;
                _softParkDbContexe=softParkDbContexe;
            }

            public async Task<Customer> Handle(GetCustomerQuerie request, CancellationToken cancellationToken)
            {
                if (request.CustomerId.HasValue)

                {
                    /*var collection = _database.GetCollection<Customer>(Constants.CategoriesCollectionName);
                    var filter = Builders<Customer>.Filter.Eq(doc => doc.Id, request.CustomerId);

                    var customer = await collection.Find(filter).ToListAsync(cancellationToken);*/


                    var customer = _softParkDbContexe.FindByIdAsync(request.CustomerId.Value);
                    
                    return customer.Result;
                }
                else
                {
                    throw new Exception("Not Found");
                }
                
            }
        }
    }
}
