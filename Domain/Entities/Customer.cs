

namespace Domain.Entities
{
    public class Customer : EntityBase
    {
        public Customer()
        {
            Customers = new List<Customer>();
        }
        public Customer(Guid id, string firstName, string lastName, string phoneNumber,  Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
           
            PhoneNumber = phoneNumber;
            
            this.address = address;
           
        }

        public Guid Id { get; private set; }

        public string FirstName { get; private set; } = "";

        public string LastName { get; private set; } = "";

       

        public string PhoneNumber { get; private set; } = "";

        

        public Address address { get; private set; }
        
        public IList<Customer> Customers{ get; private set; }
    }
  

   
}
