
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using MongoDB.Driver;

namespace Application.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
       
        

        public string? FirstName { get; set; } 

        public string? LastName { get; set; } 

        public string? PhoneNumber { get; set; } 

        public Address? address { get; set; }

        public class Handler : IRequestHandler<CreateCustomerCommand,Guid>
        {
            
            private readonly ICustomerREpository _IcustomerRepository;

            public Handler( ICustomerREpository IcustomerRepository)
            {
                
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
                    
                    return id.Result;
                }
                catch (Exception ex) {
                    throw new Exception(ex.Message);
                
                }



            }
        }
    }
}
