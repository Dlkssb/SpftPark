

namespace Domain.Entities
{
    public class House :EntityBase
    {
        public House()
        {
            houses=new List<House>();
        }

        public Guid? Id { get; private set; }
        public  string? TypeOfOffer { get; private set; }
        
        public Address? address { get; private set; }

        public IList<House> houses { get; private set; }





    }
}
