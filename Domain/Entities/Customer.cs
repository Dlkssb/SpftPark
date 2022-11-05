

namespace Domain.Entities
{
    public class Customer : Base
    {
        public Customer()
        {

        }
       
        public Customer( string firstName, string lastName, string phoneNumber,  Address address)
        {
            
            FirstName = firstName;
            LastName = lastName;
           
            PhoneNumber = phoneNumber;
            
            this.address = address;
           
        }

      
        public void EditCustomer(string firstName, string lastName, string phoneNumber, Address address)
        {
            
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.address = address;



        }

        

        public string FirstName { get; private set; } = "";

        public string LastName { get; private set; } = "";

        public string PhoneNumber { get; private set; } = "";

        public Address? address { get; private set; }
        
       
    }
  

   
}
