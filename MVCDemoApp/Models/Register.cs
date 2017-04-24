using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemoApp.Models
{
    public class Register
    {
        [Required(ErrorMessage="Enter Full Name")]
        public string FullName { get; set; }

      
        [Required(ErrorMessage = "Enter User name")]
        [Remote("CheckUserName", "Account", ErrorMessage = " User name already exists !!!")]
        public string username { get; set; }
        [Required(ErrorMessage = "Enter EmailID")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]

        public string password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.Web.Mvc.Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string Confirmpassword { get; set; }
 

    }
    public class Login
    {
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100,ErrorMessage ="The password must be at list{2} characters",MinimumLength =6)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Enter User Name")]
        public string UserName { get; set; }
    }

    public class CustomValidationForDropDown : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value ==null || value == "0")
            {
                return new ValidationResult("Please select ");
            }
            return ValidationResult.Success;
        }
    }
}