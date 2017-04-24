using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemoApp.DataRepository;
using MVCDemoApp.Models;
using System.Net;
using PagedList.Mvc;
using PagedList;
using WebMatrix.WebData;
using WebMatrix.Data;


namespace MVCDemoApp.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        static ProductContext context;
        public ProductController()
        {
            context = context ?? new  ProductContext();
            WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("DefaultConnection","Users","UserId","UserName",autoCreateTables:true);
           
        }
        public ActionResult Index(string SearchString ,string SortOrder , string CurrentFilter, int? page)
       {
            List<Product> products = context.GetAllProduct().ToList();
            ViewBag.SearString = SearchString;

            ViewBag.NameSortOrder = string.IsNullOrEmpty(SortOrder) ? "Name desc" : "Name";
            ViewBag.CategorySortOrder = string.IsNullOrEmpty(SortOrder) ? "Category desc" : "Category";
            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(p => p.Name.Contains(SearchString) || p.Category.Contains(SearchString)).ToList();
            }

            switch(SortOrder)
            {
                case "":
                products = products.OrderBy(p=>p.Name).ToList();
                    break;
                case "Name":
                    products = products.OrderBy(p=>p.Name).ToList();
                    break;
                case "Name desc":
                    products = products.OrderByDescending(p => p.Name).ToList();
                    break;
                case "Category":
                    products = products.OrderBy(p => p.Category).ToList();
                    break;
                case "Category desc":
                    products = products.OrderByDescending(p => p.Category).ToList();
                    break;
                default:
                    products = products.OrderBy(p => p.Name).ToList();
                    break;
            }
             int pageNumber =0;
            if(page !=null)
            {
                pageNumber = Convert.ToInt32(page)==0?1:Convert.ToInt32(page);
            }
            else 
            {
                pageNumber = 1;
            }
       
            return View(products.ToPagedList(pageNumber, 3));
        }
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product )
        {
            if (ModelState.IsValid)
            {
                if (product == null)
                {
                    return HttpNotFound();
                }
                context.ADDProduct(product);
                ViewBag.Message = "OK";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return View();
            

        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product == null)
                {
                    return HttpNotFound();
                }
                context.UpdateProduct(product);
                ModelState.Clear();
                ViewBag.Message = "OK";
                return RedirectToAction("Index");
            }
             ModelState.AddModelError("", "Error");
             return View("Edit");
        }

        [HttpPost]
        public ActionResult DeleteProduct(int ProductId)
        {
            if (context.GetAllProduct().FirstOrDefault(p => p.Id == ProductId) == null)
            {
                return HttpNotFound();
            }
            context.DeleteProduct(ProductId);
            ViewBag.Message = "OK";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if(context.GetAllProduct().Where(p => p.Id == id).FirstOrDefault()==null)
            {
              // return new  HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product _product = context.GetAllProduct().Where(p => p.Id == id).FirstOrDefault();
            return View(_product);
        }

        public ActionResult CreateDropdownlistAndRadioButton()
        {
            return View();
        }
        
        public ActionResult GetAllproduct()
        {
           return  Json(context.GetAllProduct(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ActionName("GetAllproduct")]
        public ActionResult GetAllproduct1()
        {
            System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
        string str =    Newtonsoft.Json.JsonConvert.SerializeObject(DateTime.Now);
        return Json(str, JsonRequestBehavior.DenyGet);
        }

        public ActionResult Upload()
        {
            return View();
        }
        public ActionResult GetData()
        {
            return View();
        }
	}
}