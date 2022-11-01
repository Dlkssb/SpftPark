
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using MongoDB.Driver;

namespace Application.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
       
        public Guid Id { get; set; }

        public string? FirstName { get; set; } 

        public string? LastName { get; set; } 

        public string? PhoneNumber { get; set; } 

        public Address? address { get; set; }

        public class Handler : IRequestHandler<CreateCustomerCommand,Guid>
        {
            private readonly IMongoDatabase _context;
            private readonly ISoftParkDbContext<Customer> _softParkDbContext;

            public Handler(IMongoClient context, ISoftParkDbContext<Customer> softParkDbContext)
            {
                _context = context.GetDatabase(Constants.GetDatabaseName());
                _softParkDbContext = softParkDbContext;
            }
            public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                

                try
                {
                    var entitiy = new Customer(
                        request.Id,
                        request.FirstName,
                        request.LastName,
                        request.PhoneNumber,
                        request.address
                        );

                    var id=_softParkDbContext.InsertOneAsync(entitiy,cancellationToken);

                  /*  var collection = _context.GetCollection<Customer>(Constants.CategoriesCollectionName);

                    await collection.InsertOneAsync(entitiy, null, cancellationToken);*/
                    
                    return request.Id;
                }
                catch (Exception ex) {
                    throw new Exception(ex.Message);
                
                }



            }
        }
    }
}
