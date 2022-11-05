using Application.Interfaces;
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
    public class GetCustomersQuerie : IRequest<IList<Customer>>
    {
        public class GetCustomersHandler : IRequestHandler<GetCustomersQuerie, IList<Customer>>
        {

            private readonly ICustomerREpository _IcustomerRepository;

            public GetCustomersHandler( ICustomerREpository IcustomerRepository)
            {
                
                _IcustomerRepository = IcustomerRepository;
                
            }
            
            public async Task<IList<Customer>> Handle(GetCustomersQuerie request, CancellationToken cancellationToken)
            {
                    var customers =await _IcustomerRepository.GetAll(cancellationToken);
                    return customers;
            }
        }
    }
}
