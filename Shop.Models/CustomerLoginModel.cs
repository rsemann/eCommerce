using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class CustomerLoginModel
    {
        [Key]
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid e-mail address")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
