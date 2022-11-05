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
            private readonly IHouseRepository _IhouseRepository;

            public DeleteHouseHandler(IHouseRepository IhouseRepository)
            {
                _IhouseRepository = IhouseRepository;
            }

            public async Task<Unit> Handle(DeleteHouseCommand request, CancellationToken cancellationToken)
            {
                var house =  _IhouseRepository.DeleteByIdAsync(request.Id,cancellationToken);

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
