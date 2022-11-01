

namespace Domain.Entities
{
    public class House :EntityBase
    {
        public House()
        {
            houses=new List<House>();
        }
        public House(Guid? id, string? typeOfOffer, Address? address, string imageUri)
        {
            Id = id;
            TypeOfOffer = typeOfOffer;
            this.address = address;
            ImageUri = imageUri;
        }

        public Guid? Id { get; private set; }
        public  string? TypeOfOffer { get; private set; }
        
        public Address? address { get; private set; }

        public string ImageUri { get; private set; }

        public IList<House> houses { get; private set; }





    }
}
