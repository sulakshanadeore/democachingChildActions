using democachingChildActions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace democachingChildActions.Controllers
{
    public class CustomerProductsController : Controller
    {
        static List<Prod> plist = new List<Prod>();


        [NonAction]
        public void populateProducts()
        {
       plist.Add(new Prod { Pid = 1, Pname = "chocolates", Price = 10 });
       plist.Add(new Prod { Pid = 2, Pname = "Kitkat", Price = 20 });
       plist.Add(new Prod { Pid = 3, Pname = "Cadbury", Price = 10 });
       plist.Add(new Prod { Pid = 4, Pname = "Silk", Price = 150 });
       plist.Add(new Prod { Pid = 5, Pname = "Nuts Silk", Price = 100 });

            //return View();
        }
        //static CustomerProductsController()
        //{
        //    plist.Add(new Prod { Pid = 1, Pname = "chocolates", Price = 10 });
        //    plist.Add(new Prod { Pid = 2, Pname = "Kitkat", Price = 20 });
        //    plist.Add(new Prod { Pid = 3, Pname = "Cadbury", Price = 10 });
        //    plist.Add(new Prod { Pid = 4, Pname = "Silk", Price = 150 });
        //    plist.Add(new Prod { Pid = 5, Pname = "Nuts Silk", Price = 100 });



        //}

        // GET: CustomerProducts
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ProductList()
        {
            populateProducts();
            var pdata = from p in plist
                        orderby p.Price
                        select p;
            return View(pdata);
            
        }


    }
}