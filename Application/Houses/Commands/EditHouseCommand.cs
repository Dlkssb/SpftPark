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
        public Guid Id { get;  set; }
        public string TypeOfOffer { get;  set; }

        public Address address { get;  set; }

        public string ImageUri { get;  set; }

        public class EditHouseHandler : IRequestHandler<EditHouseCommand, Guid>
        {
            private readonly ISoftParkDbContext<House> _softParkDbContext;
            public EditHouseHandler(ISoftParkDbContext<House> softParkDbContext)
            {
                _softParkDbContext = softParkDbContext;
            }

            public async Task<Guid> Handle(EditHouseCommand request, CancellationToken cancellationToken)
            {
                var house =  _softParkDbContext.FindByIdAsync(request.Id, cancellationToken);

                if (house != null)
                {
                    var newHouse = new House(
                        request.Id,
                        request.TypeOfOffer,
                        request.address,
                        request.ImageUri
                        
                        );

                    var resulte = await _softParkDbContext.ReplaceOneAsync(newHouse,cancellationToken);

                   
                    return resulte;

                }
                else
                {
                    throw new Exception("not found");
                }

            }
        }
    }
}
