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
    public class GetHouseQuerie :IRequest<House>
    {
        public Guid Id { get; set; }

        public class GetHouseHandler : IRequestHandler<GetHouseQuerie, House>
        {
            private readonly ISoftParkDbContext<Customer> _softParkDbContext;

            public GetHouseHandler(ISoftParkDbContext<Customer> softParkDbContext)
            {
                _softParkDbContext = softParkDbContext;
            }

            public Task<House> Handle(GetHouseQuerie request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
