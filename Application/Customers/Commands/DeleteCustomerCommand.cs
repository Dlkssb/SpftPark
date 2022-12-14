using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest
    {

        public Guid Id { get; set; }

        public class DeleteCustomerHandler :IRequestHandler<DeleteCustomerCommand>
        {
           
            private readonly ICustomerREpository _IcustomerRepository;
            public DeleteCustomerHandler( ICustomerREpository IcustomerRepository)
            {
                
                _IcustomerRepository = IcustomerRepository;
            }

            public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
               /* var collection = _database.GetCollection<Customer>(Constants.CategoriesCollectionName);
                var objectId = request.Id;
                var filter = Builders<Customer>.Filter.Eq(doc => doc.Id, objectId);
                var customer = await collection.Find(filter).FirstOrDefaultAsync(cancellationToken);*/
               var customer= _IcustomerRepository.DeleteByIdAsync(request.Id,cancellationToken);

                if(customer !=null)
                {
                   /*await collection.DeleteOneAsync(filter);*/
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
