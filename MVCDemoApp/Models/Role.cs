using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace MVCDemoApp.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Enter Role name")]
        public string RoleName { get; set; }
    }
    public class AssignRoleVM
    {

        [Required(ErrorMessage = "Select Role Name")]
        [CustomValidationForDropDown]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "Select User name")]
        public string UserName { get; set; }
        public List<System.Web.Mvc.SelectListItem> Userlist { get; set; }
         [CustomValidationForDropDown]
        public List<System.Web.Mvc.SelectListItem> RolesList { get; set; }
    }

    public class AllroleandUser
    {
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public List<AllroleandUser> AllDetailsUserlist { get; set; }
    }  
}