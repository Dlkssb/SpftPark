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
            private readonly ISoftParkDbContext<House> _softParkDbContext;

            public GetHousesHandler(ISoftParkDbContext<House> softParkDbContext)
            {
                _softParkDbContext = softParkDbContext;
            }

            public async Task<IList<House>> Handle(GetHousesQuerie request, CancellationToken cancellationToken)
            {
                var houses=_softParkDbContext.GetAll(cancellationToken);
                return houses.Result;
            }
        }
    }
}
