using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Houses.Queries
{
    public class GetHousesQuerie : IRequest<IList<House>>
    {

        public class GetHousesHandler : IRequestHandler<GetHousesQuerie, IList<House>>
        {
            private readonly IHouseRepository _IhouseRepository;

            public GetHousesHandler(IHouseRepository IhouseRepository)
            {
                _IhouseRepository = IhouseRepository;
            }

            public async Task<IList<House>> Handle(GetHousesQuerie request, CancellationToken cancellationToken)
            {
                var houses=await _IhouseRepository.GetAll(cancellationToken);
                return houses;
            }
        }
    }
}
