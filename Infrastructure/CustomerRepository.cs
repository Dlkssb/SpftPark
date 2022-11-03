using Application;
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
        public CustomerRepository(IMongoClient database, string CollectionName) : base(database, CollectionName)
        {
            CollectionName = GetCollectionName();
        }

        public string GetCollectionName()
        {
           return Constants.CustomerCollectionName;
        }
    }
}
