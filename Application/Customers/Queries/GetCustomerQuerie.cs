using AutoMapper;
using Domain.Entities;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Queries
{
    public class GetCustomerQuerie : IRequest<Customer>
    {
        public Guid? CustomerId { get; set; }
        public string? FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public Address address { get; set; }    

        public class GetCustomerHandler : IRequestHandler<GetCustomerQuerie, Customer>
        {
           
            private readonly IMongoDatabase _database;
            public GetCustomerHandler(IMongoClient database)
            {
                _database=database.GetDatabase(Constants.GetDatabaseName());
            }

            public Task<Customer> Handle(GetCustomerQuerie request, CancellationToken cancellationToken)
            {
                if (request.CustomerId.HasValue)
                {
                    var customer = new Customer(
                       request.CustomerId.Value,
                       request.FirstName,
                       request.LastName,
                       request.PhoneNumber,
                       request.address
                        );
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
