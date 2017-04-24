using MVCDemoApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MVCDemoApp.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
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
            return View();
        }

        [HttpGet]
        [ActionName("Upload")]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Main")]
        public ActionResult Registe()
        {
            return View("Upload");
        }
        [HttpPost]
        public ActionResult Upload(List<HttpPostedFileBase> postedFile)
        {
        //    HttpPostedFileBase postedFile
            foreach (HttpPostedFileBase item in postedFile)
            {
                if (item.HasFile())
                {
                    item.SaveAs(Server.MapPath(string.Format("~/Upload/{0}", Path.GetFileName(item.FileName))));
                    ViewBag.Message = "File uploaded successfully.";
                }
           }
           
            return View();
        }
	}
}