namespace UI.Models
{
    public class House
    {
        public Guid Id { get; set; }
        public string? TypeOfOffer { get;  set; }

        public Address? address { get;  set; }

        public string ImageUri { get;  set; }

       
    }
}
