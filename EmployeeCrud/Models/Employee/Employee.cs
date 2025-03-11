using System.ComponentModel.DataAnnotations;

namespace EmployeeCrud.Models.Employee
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        [Required]
        [Display(Name = "Department")]
        public string Department { get; set; }
        [Required]
        [Display(Name = "JoiningDate")]
        public DateOnly Joining_date { get; set; }
    }
}
