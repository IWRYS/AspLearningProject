using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspNetCoreLearningProject.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password doesn't match !")]    
        public string  ConfirmPassword { get; set; }
    }
}
