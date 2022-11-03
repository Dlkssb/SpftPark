
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
            private readonly ICustomerREpository _IcustomerRepository;

            public Handler(IMongoClient context, ICustomerREpository IcustomerRepository)
            {
                _context = context.GetDatabase(Constants.GetDatabaseName());
                _IcustomerRepository = IcustomerRepository;
            }
            public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                

                try
                {
                    var entitiy = new Customer(
                        request.FirstName,
                        request.LastName,
                        request.PhoneNumber,
                        request.address
                        );

                    var id= _IcustomerRepository.InsertOneAsync(entitiy,cancellationToken);

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
