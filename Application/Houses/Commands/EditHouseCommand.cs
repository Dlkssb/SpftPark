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
    public class EditHouseCommand :IRequest<Guid>
    {
        public Guid? Id { get;  set; }
        public string? TypeOfOffer { get;  set; }

        public Address? address { get;  set; }

        public string ImageUri { get;  set; }

        public class EditHouseHandler : IRequestHandler<EditHouseCommand, Guid>
        {
            private readonly ISoftParkDbContext<Customer> _softParkDbContext;
            public EditHouseHandler(ISoftParkDbContext<Customer> softParkDbContext)
            {
                _softParkDbContext = softParkDbContext;
            }

            public Task<Guid> Handle(EditHouseCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
