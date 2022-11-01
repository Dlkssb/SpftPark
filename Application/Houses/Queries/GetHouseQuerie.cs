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
        public Guid? Id { get; set; }

        public class GetHouseHandler : IRequestHandler<GetHouseQuerie, House>
        {
            private readonly ISoftParkDbContext<House> _softParkDbContext;

            public GetHouseHandler(ISoftParkDbContext<House> softParkDbContext)
            {
                _softParkDbContext = softParkDbContext;
            }

            public async async Task<House> Handle(GetHouseQuerie request, CancellationToken cancellationToken)
            {
                if (request.Id.HasValue)

                {
                    /*var collection = _database.GetCollection<Customer>(Constants.CategoriesCollectionName);
                    var filter = Builders<Customer>.Filter.Eq(doc => doc.Id, request.CustomerId);

                    var customer = await collection.Find(filter).ToListAsync(cancellationToken);*/


                    var customer = await _softParkDbContext.FindByIdAsync(request.Id.Value,cancellationToken);

                    return customer;
                }
                else
                {
                    throw new Exception("Not Found");
                }
            }
        }
    }
}
