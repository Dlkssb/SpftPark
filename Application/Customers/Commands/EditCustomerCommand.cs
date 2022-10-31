using Domain.Entities;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Commands
{
    public class EditCustomerCommand :IRequest<Guid>
    {
        public Guid CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address address { get; set; }

        public string PhoneNumber { get; set; }

        public class EditCustomerHandler : IRequestHandler<EditCustomerCommand, Guid>
        {
           private readonly IMongoDatabase _database;
            public EditCustomerHandler(IMongoClient database)
            {
                _database = database.GetDatabase(Constants.GetDatabaseName());
            }
            public async Task<Guid> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
            {
                Guid Id=request.CustomerId;
                var collection = _database.GetCollection<Customer>(Constants.CategoriesCollectionName);
                var filter= Builders<Customer>.Filter.Eq(doc => doc.Id, Id);
                var customer=collection.Find(filter);
                if(customer!=null)
                {
                    var NewCustomer = new Customer(
                        request.CustomerId,
                        request.FirstName,
                        request.LastName,
                        request.PhoneNumber,
                        request.address
                        );

                    await collection.ReplaceOneAsync(filter, NewCustomer, new UpdateOptions { IsUpsert=true} , cancellationToken);
                    
                    return request.CustomerId;

                }
                else
                {
                    throw new Exception("not found");
                }
            }
        }
    }
}
