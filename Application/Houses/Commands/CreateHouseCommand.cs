using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Houses.Commands
{
    public class CreateHouseCommand :IRequest<Guid>
    {
        public Guid? Id { get;  set; }
        public string? TypeOfOffer { get;  set; }

        public Address? address { get;  set; }

        public string ImageUrl { get;  set; }

        public class CreateHouseHandler : IRequestHandler<CreateHouseCommand, Guid>
        {
            private readonly ISoftParkDbContext<Customer> _softParkDbContext;
            public CreateHouseHandler(ISoftParkDbContext<Customer> softParkDbContext)
            {
                _softParkDbContext = softParkDbContext;
            }

            public Task<Guid> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
