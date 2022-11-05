using Application;
using Application.Customers.Queries;
using Application.Interfaces;
using Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerREpository
    {
        public static  string _CollectionName="Customers";
        public CustomerRepository(IMongoClient database) : base(database, _CollectionName)
        {
            
        }

        public string GetCollectionName()
        {
           return Constants.CustomerCollectionName;
        }
    }
}
