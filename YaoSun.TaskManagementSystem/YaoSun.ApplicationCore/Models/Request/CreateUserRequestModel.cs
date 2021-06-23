using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaoSun.ApplicationCore.Models.Request
{
    public class CreateUserRequestModel
    {
        [Required(ErrorMessage = "Please make sure Email is not blank")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please make sure Password is not blank")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage =
            "Password Should have minimum 8 with at least one upper, lower, number and special character")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Please make sure Fullname is not blank")]
        [StringLength(50)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Please make sure Mobileno is not blank")]
        [StringLength(50)]
        public string Mobileno { get; set; }
    }
}
