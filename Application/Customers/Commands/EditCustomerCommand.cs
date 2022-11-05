using Application.Interfaces;
using Domain.Entities;
using MediatR;
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
            private readonly ICustomerREpository _IcustomerRepository;
            public EditCustomerHandler( ICustomerREpository IcustomerRepository)
            {
                _IcustomerRepository = IcustomerRepository;
            }
            public async Task<Guid> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = await _IcustomerRepository.FindByIdAsync(request.CustomerId,cancellationToken);
                if(customer!=null)
                {
                    customer.EditCustomer
                        (
                        request.FirstName,
                        request.LastName,
                        request.PhoneNumber,
                        request.address
                        );
                    
                    
                    var resulte= _IcustomerRepository.ReplaceOneAsync(customer, cancellationToken);
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
