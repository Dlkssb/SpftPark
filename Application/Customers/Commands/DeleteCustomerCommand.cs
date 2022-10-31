using Domain.Entities;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest
    {

        public Guid Id { get; set; }

        public class DeleteCustomerHandler :IRequestHandler<DeleteCustomerCommand>
        {
            private readonly IMongoDatabase _database;
            public DeleteCustomerHandler(IMongoClient database)
            {
                _database = database.GetDatabase(Constants.GetDatabaseName());
            }

            public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                var collection = _database.GetCollection<Customer>(Constants.CategoriesCollectionName);
                var objectId = request.Id;
                var filter = Builders<Customer>.Filter.Eq(doc => doc.Id, objectId);
                var customer = await collection.Find(filter).FirstOrDefaultAsync(cancellationToken);

                if(customer !=null)
                {
                   await collection.DeleteOneAsync(filter);
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Customer not found");
                }
            }
        }
            
    }
}
