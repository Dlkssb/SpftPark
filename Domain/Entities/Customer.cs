

namespace Domain.Entities
{
    public class Customer : Base
    {
        public Customer()
        {
            Customers = new List<Customer>();
        }
        public Customer( string firstName, string lastName, string phoneNumber,  Address address)
        {
            
            FirstName = firstName;
            LastName = lastName;
           
            PhoneNumber = phoneNumber;
            
            this.address = address;
           
        }

        

        public string FirstName { get; private set; } = "";

        public string LastName { get; private set; } = "";

       

        public string PhoneNumber { get; private set; } = "";

        

        public Address address { get; private set; }
        
        public IList<Customer> Customers{ get; private set; }
    }
  

   
}
