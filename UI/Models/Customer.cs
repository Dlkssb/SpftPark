using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class Customer
    {

        public Guid Id { get; set; }
        [Required]
        public string FirstName { get;  set; } = "";
        [Required]
        public string LastName { get;  set; } = "";
        [Required]
        [StringLength(10,ErrorMessage ="",MinimumLength =10)]
        public string PhoneNumber { get;  set; } = "";
        [Required]
        public Address address { get; set; } = new Address();
    }
}
