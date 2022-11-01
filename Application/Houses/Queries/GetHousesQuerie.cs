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
            private readonly ISoftParkDbContext<Customer> _softParkDbContext;

            public GetHousesHandler(ISoftParkDbContext<Customer> softParkDbContext)
            {
                _softParkDbContext = softParkDbContext;
            }

            public Task<IList<House>> Handle(GetHousesQuerie request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
