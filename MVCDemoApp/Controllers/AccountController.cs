using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemoApp.Models;
using WebMatrix.WebData;
using WebMatrix.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Security;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCDemoApp.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [MVCDemoApp.Filter.MyExceptionHandler]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                if (!WebSecurity.UserExists(register.username))
                {
                    string str = WebSecurity.CreateUserAndAccount(register.username, register.password);
                    ViewBag.Success = "User Created Successfully";
                    ModelState.Clear();
                    return View();
                }
                ModelState.AddModelError("Error", "User Already Exists!!!");
            }
            return RedirectToAction("Index", "Register");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.UserExists(login.UserName))
                {
                    if(WebSecurity.Login(login.UserName, login.Password))
                    {
                        ViewBag.Message = "Success";
                        return View();
                    }
                   // ViewBag.Message = "Invalid Login";
                }
                ViewBag.Message = "Fail";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Role()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Role(Role role)
        {
            if(ModelState.IsValid)
            {
            if(!Roles.RoleExists(role.RoleName))
            {
                Roles.CreateRole(role.RoleName);
                ModelState.Clear();
                ViewBag.Message = "Success";
                return View();
            }
                ViewBag.Message = "Fail";
                return View();
            }
            return View();
        }

        

        [HttpGet]
        public ActionResult AddRoleToUser()
        {
            List<SelectListItem> roles = Roles.GetAllRoles().Select(p => new SelectListItem { Text = p, Value = p }).OrderBy(p=>p.Text).ToList();
            List<SelectListItem> users = new List<SelectListItem>(); 
            AssignRoleVM objRoleVM = new AssignRoleVM();
            string sql = "select UserId, UserName from Users";
            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                var output = con.Query(sql).ToList().OrderBy(p=>p.UserName);
                foreach ( var item in output)
                {
                    users.Add(new SelectListItem { Text = item.UserName, Value = Convert.ToString(item.UserName) });
                }
            }
           objRoleVM.RolesList = roles;
           objRoleVM.Userlist = users;
           return View(objRoleVM);
        }

        [HttpPost]
        public ActionResult AddRoleToUser(AssignRoleVM assignRoleVM)
        {
            if(ModelState.IsValid)
            {
                if (Roles.IsUserInRole(assignRoleVM.UserName, assignRoleVM.RoleName))
                {
                    ViewBag.Message = "Fail";
                    //return View(assignRoleVM);
                }
                else
                {
                    Roles.AddUserToRole(assignRoleVM.UserName, assignRoleVM.RoleName);
                    ModelState.Clear();
                    ViewBag.Message = "Success";
                }
             // return RedirectToAction("AddRoleToUser", "Account");
            }
            if(string.IsNullOrEmpty(assignRoleVM.RoleName))
            {
                ModelState.AddModelError("RoleName", "Select Role");
            }
            if (string.IsNullOrEmpty(assignRoleVM.UserName))
            {
                ModelState.AddModelError("UserName", "Select User");
            }

            List<SelectListItem> roles = Roles.GetAllRoles().Select(p => new SelectListItem { Text = p, Value = p, Selected = string.IsNullOrEmpty(assignRoleVM.RoleName) && ViewBag.Message =="Fail" ? true : false}).OrderBy(p => p.Text).ToList();
            List<SelectListItem> users = new List<SelectListItem>();
           
            string sql = "select UserId, UserName from Users";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                var output = con.Query(sql).ToList().OrderBy(p => p.UserName);
                foreach (var item in output)
                {
                    users.Add(new SelectListItem { Text = item.UserName, Value = Convert.ToString(item.UserName), Selected = string.IsNullOrEmpty(assignRoleVM.UserName) && ViewBag.Message == "Fail" ? true : false });
                }
            }
            assignRoleVM.RolesList = roles;
            assignRoleVM.Userlist = users;
            return View(assignRoleVM);

        }

        public ActionResult ViewAllRole()
        {
            return View();
        }


        public ActionResult CheckUserName(string username)
         {
            bool checkemail = username.Equals("vinay.pandey@annik.com") ? true : false;
            return Json(!checkemail, JsonRequestBehavior.AllowGet);
        }
        
	}
}