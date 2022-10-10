using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using democachingChildActions.Models;
namespace democachingChildActions.Controllers
{
    public class ProductsController : Controller
    {
        static List<Prod> plist = new List<Prod>();
        static ProductsController()
        {
            plist.Add(new Prod {Pid=1,Pname="chocolates",Price=10 });
            plist.Add(new Prod { Pid = 2, Pname = "Kitkat", Price = 20 });
            plist.Add(new Prod { Pid = 3, Pname = "Cadbury", Price = 10 });
            plist.Add(new Prod { Pid = 4, Pname = "Silk", Price = 150 });
            plist.Add(new Prod { Pid = 5, Pname = "Nuts Silk", Price = 100 });



        }
        // GET: Products
        //[OutputCache(Duration =20)]
        [OutputCache(CacheProfile = "basic")]
        public ActionResult Index()
        {
            var pdata = from p in plist
                        orderby p.Price
                        select p;
            return View(pdata);
        }


        //public ActionResult Details()
        //{

        //    return View();
        //}
        //[OutputCache(Duration =int.MaxValue,VaryByParam ="id")]
        [OutputCache(CacheProfile = "idChange")]
         public ActionResult Details(int id)
        {
                
            Prod prodfound = new Prod();
            prodfound=(from p1 in plist
                            where p1.Pid == id
                            select p1).First();
            return View(prodfound);
        }
    }
}