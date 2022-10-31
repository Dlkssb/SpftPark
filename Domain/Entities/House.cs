using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class House
    {
        public House()
        {
            houses=new List<House>();
        }

        public Guid? id { get; private set; }
        public  string? TypeOfOffer { get; private set; }
        
        public Address? address { get; private set; }

        public IList<House> houses { get; private set; }





    }
}
