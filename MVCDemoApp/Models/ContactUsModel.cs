using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemoApp.Models
{
    public class ContactUsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public HttpPostedFileBase attachment { get; set; }
    }
    public static class ExtensionMethods 
    {
        public static bool HasFile(this HttpPostedFileBase file)
        {
            return file != null && file.ContentLength > 0;
        }
    }
}