using asp.net.LearningProject.Models.AdressModels;
using asp.net.LearningProject.Models.EmployeesModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace asp.net.LearningProject.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Name cannot exceed 50 characters!")]
        [MinLength(3, ErrorMessage = "Name cannot be less than 3 characters!")]
        public string Name { get; set; }

        [Required]
       // [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$)]",ErrorMessage ="Invalid Email Format!")]
        public string Email { get; set; }

        [Required]
        public Departament? Department { get; set; }
        public int TownId { get; set; }
        public Town Town { get; set; }



      
    }
}
    