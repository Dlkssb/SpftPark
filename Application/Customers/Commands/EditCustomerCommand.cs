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
            private readonly ICustomerREpository _IcustomerRepository;
            public EditCustomerHandler(IMongoClient database, ICustomerREpository IcustomerRepository)
            {
                _database = database.GetDatabase(Constants.GetDatabaseName());
                _IcustomerRepository = IcustomerRepository;
            }
            public async Task<Guid> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
            {
                /*Guid Id=request.CustomerId;
                var collection = _database.GetCollection<Customer>(Constants.CategoriesCollectionName);
                var filter= Builders<Customer>.Filter.Eq(doc => doc.Id, Id);
                var customer=collection.Find(filter);*/

                var customer = await _IcustomerRepository.FindByIdAsync(request.CustomerId,cancellationToken);
                if(customer!=null)
                {
                    var NewCustomer = new Customer(
                        
                        request.FirstName,
                        request.LastName,
                        request.PhoneNumber,
                        request.address
                        );

                    var resulte= _IcustomerRepository.ReplaceOneAsync(NewCustomer,cancellationToken);
                    
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
