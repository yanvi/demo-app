using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemoApp.Models;

namespace MVCDemoApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string pictureFileName = @"D:\Vinay\Data\MVCDemoApp\MVCDemoApp\Upload\AddNewUser.png";
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=SavetoPPT.ppt");
            Response.ContentType = "application/vnd.ms-powerpoint";
            String imagepath = "<img src='" + pictureFileName + "' width='780' height='480'/>";
            Response.Output.Write(imagepath);
            Response.Flush();
            Response.End();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}