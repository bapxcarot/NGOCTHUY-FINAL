using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAYCANHNT.Models;

namespace CAYCANHNT.Controllers
{
    public class ProductController : Controller
    {
        CAYCANHNTEntities _db = new CAYCANHNTEntities();

        // GET: Product
        public ActionResult Index(string meta)
        {
            var v = from t in _db.CATOLOGies
                    where t.META == meta
                    select t;
            return View(v.FirstOrDefault());
        }

        public ActionResult Detail(long id)
        {
            var v = from t in _db.PRODUCTS
                    where t.ID_PRO == id
                    select t;
            return View(v.FirstOrDefault());
        }
    }
}