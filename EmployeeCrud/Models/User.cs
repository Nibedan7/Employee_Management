using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeCrud.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        //[RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$\r\n", ErrorMessage = "Not a valid Email!!")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
        
    }
}
