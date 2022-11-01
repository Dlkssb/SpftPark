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
        public Guid Id { get;  set; }

        public class DeleteHouseHandler : IRequestHandler<DeleteHouseCommand>
        {
            private readonly ISoftParkDbContext<House> _softParkDbContext;

            public DeleteHouseHandler(ISoftParkDbContext<House> softParkDbContext)
            {
                _softParkDbContext = softParkDbContext;
            }

            public async Task<Unit> Handle(DeleteHouseCommand request, CancellationToken cancellationToken)
            {
                var house =   _softParkDbContext.DeleteByIdAsync(request.Id,cancellationToken);

                if (house != null)
                {
                    
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
