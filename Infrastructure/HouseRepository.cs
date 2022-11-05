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
    public class HouseRepository : RepositoryBase<House>, IHouseRepository
    {
      public static  string _Collection="Houses";
        public HouseRepository(IMongoClient database) : base(database, _Collection)
        {

            
            
        }

        public string GetCollectionName()
        {
            return Constants.HousesCollectionName;
        }
    }
}
