using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemoApp.Filter
{
  public  class  MyExceptionHandler:ActionFilterAttribute
  {
      public override void OnActionExecuting(ActionExecutingContext filterContext)
      {
          if (filterContext.HttpContext.Session["UserId"] != null)
          {
              filterContext.Result = new RedirectResult("/Account/Login");
          }

          base.OnActionExecuting(filterContext);
      }
  }
}