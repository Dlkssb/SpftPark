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
            private readonly IHouseRepository _IhouseRepository;
            public EditHouseHandler(IHouseRepository IhouseRepository)
            {
                _IhouseRepository = IhouseRepository;
            }

            public async Task<Guid> Handle(EditHouseCommand request, CancellationToken cancellationToken)
            {
                var house = await _IhouseRepository.FindByIdAsync(request.Id, cancellationToken);

                if (house != null)
                {
                   house.EditHouse(

                        request.TypeOfOffer,
                        request.ImageUri,
                        request.address
                        

                        );

                    var resulte = await _IhouseRepository.ReplaceOneAsync(house, cancellationToken);

                   
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
