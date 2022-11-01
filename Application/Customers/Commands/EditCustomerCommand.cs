using Application.Interfaces;
using Domain.Entities;
using MediatR;
using MongoDB.Driver;

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
            private readonly ISoftParkDbContext<Customer> _softParkDbContext;
            public EditCustomerHandler(IMongoClient database, ISoftParkDbContext<Customer> softParkDbContext)
            {
                _database = database.GetDatabase(Constants.GetDatabaseName());
                _softParkDbContext = softParkDbContext;
            }
            public async Task<Guid> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
            {
                /*Guid Id=request.CustomerId;
                var collection = _database.GetCollection<Customer>(Constants.CategoriesCollectionName);
                var filter= Builders<Customer>.Filter.Eq(doc => doc.Id, Id);
                var customer=collection.Find(filter);*/

                var customer = await _softParkDbContext.FindByIdAsync(request.CustomerId,cancellationToken);
                if(customer!=null)
                {
                    var NewCustomer = new Customer(
                        request.CustomerId,
                        request.FirstName,
                        request.LastName,
                        request.PhoneNumber,
                        request.address
                        );

                    var resulte=_softParkDbContext.ReplaceOneAsync(NewCustomer);
                    
                   // await collection.ReplaceOneAsync(filter, NewCustomer, new UpdateOptions { IsUpsert=true} , cancellationToken);
                    
                    return resulte.Result;

                }
                else
                {
                    throw new Exception("not found");
                }
            }
        }
    }
}
