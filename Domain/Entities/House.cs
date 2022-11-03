

namespace Domain.Entities
{
    public class House :Base
    {
        public House()
        {
            houses=new List<House>();
        }
        public House( string? typeOfOffer, Address? address, string imageUri)
        {
           
            TypeOfOffer = typeOfOffer;
            this.address = address;
            ImageUri = imageUri;
        }

        
        public  string? TypeOfOffer { get; private set; }
        
        public Address? address { get; private set; }

        public string ImageUri { get; private set; }

        public IList<House> houses { get; private set; }





    }
}
