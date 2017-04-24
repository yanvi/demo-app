using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemoApp.Filter
{
    public class MyErrorHandler:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            if (ex != null)
            {
                filterContext.Result = new ViewResult() 
                {
                    ViewName ="Error"
                };
            }
            base.OnException(filterContext);
        }
    }
}