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
            private readonly ISoftParkDbContext<House> _softParkDbContext;
            public CreateHouseHandler(ISoftParkDbContext<House> softParkDbContext)
            {
                _softParkDbContext = softParkDbContext;
            }

            public async Task<Guid> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
            {

                try
                {
                    var entitiy = new House(
                        request.Id,
                        request.TypeOfOffer,
                        request.address,
                        request.ImageUrl

                        );

                    var id = await _softParkDbContext.InsertOneAsync(entitiy, cancellationToken);

                    return id;
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }


                throw new NotImplementedException();
            }
        }
    }
}
