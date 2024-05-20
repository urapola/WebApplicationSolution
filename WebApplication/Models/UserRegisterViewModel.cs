using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class UserRegisterViewModel
    {
        [Required]
        [StringLength(10, MinimumLength = 4)]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone")]
        public int Phone { get; set; }
    }
}
