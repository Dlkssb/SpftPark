using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using MongoDB.Driver;
using SharpCompress.Common;

namespace Application.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
       
        public Guid Id { get; set; }

        public string? FirstName { get; set; } 

        public string? LastName { get; set; } 

        public string? PhoneNumber { get; set; } 

        public Address? address { get; set; }

        public class Handler : IRequestHandler<CreateCustomerCommand,Guid>
        {
            private readonly IMongoDatabase _context;
            private readonly ISoftParkDbContext<Customer> _softParkDbContext;

            public Handler(IMongoClient context, ISoftParkDbContext<Customer> softParkDbContext)
            {
                _context = context.GetDatabase(Constants.GetDatabaseName());
                _softParkDbContext = softParkDbContext;
            }
            public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                

                try
                {
                    var entitiy = new Customer(
                        request.Id,
                        request.FirstName,
                        request.LastName,
                        request.PhoneNumber,
                        request.address
                        );

                    var id=_softParkDbContext.InsertOneAsync(entitiy);

                  /*  var collection = _context.GetCollection<Customer>(Constants.CategoriesCollectionName);

                    await collection.InsertOneAsync(entitiy, null, cancellationToken);*/
                    
                    return id.Result;
                }
                catch (Exception ex) {
                    throw new Exception(ex.Message);
                
                }



            }
        }
    }
}
