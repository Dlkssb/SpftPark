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
    public class DeleteHouseCommand :IRequest
    {
        public Guid? Id { get; private set; }

        public class DeleteHouseHandler : IRequestHandler<DeleteHouseCommand>
        {
            private readonly ISoftParkDbContext<Customer> _softParkDbContext;

            public DeleteHouseHandler(ISoftParkDbContext<Customer> softParkDbContext)
            {
                _softParkDbContext = softParkDbContext;
            }

            public Task<Unit> Handle(DeleteHouseCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
