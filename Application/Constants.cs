using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Constants
    {
        public const string DatabaseName = "SoftPark";
        public const string ConnectionString = "mongodb://localhost:27017";

        public static string GetDatabaseName()
        {
            var name = Environment.GetEnvironmentVariable("DB_NAME");
            if (name == null)
                throw new Exception("Database name was not found in the env variables.");
            return name;
        }

        public const string CustomerCollectionName = "Customers";
        public const string HousesCollectionName = "Houses";
        public const string AddressesCollectionName = "Addresses";

    }
}
