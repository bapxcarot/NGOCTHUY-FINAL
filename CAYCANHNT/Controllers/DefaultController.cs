using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAYCANHNT.Models;

namespace CAYCANHNT.Controllers
{
    public class DefaultController : Controller
    {
        CAYCANHNTEntities _db = new CAYCANHNTEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getSlider()
        {
            var v = from t in _db.SLIDERs
                    where t.HIDE == 0
                    orderby t.ORDER ascending
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getCatologyMain()
        {
            //var catology=_db.Menus.where(x=>x.id==3).firstordefault();
            ViewBag.meta = "danh-muc";
            var v = (from t in _db.CATOLOGies
                     where t.HIDE == 0
                     orderby t.ORDER ascending
                     select t).Take(4);
            return PartialView(v.ToList());
        }

        public ActionResult getProduct(long id, string metatitle)
        {
            //ViewBag.Metatitle = metatitle;
            var v = (from t in _db.PRODUCTS
                    where t.ID_CAT == id && t.HIDE == 0
                    orderby t.ORDER ascending
                    select t).Take(4);
            return PartialView(v.ToList());
        }

        public ActionResult getProductShop(long id, string metatitle)
        {
            //ViewBag.Metatitle = metatitle;
            var v = from t in _db.PRODUCTS
                     where t.ID_CAT == id && t.HIDE == 0
                     orderby t.ORDER ascending
                     select t;
            return PartialView(v.ToList());
        }
    }
}