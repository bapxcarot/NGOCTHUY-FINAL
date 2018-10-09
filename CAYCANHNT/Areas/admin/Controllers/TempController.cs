using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAYCANHNT.Models;

namespace CAYCANHNT.Areas.admin.Controllers
{
    public class TempController : Controller
    {
        CAYCANHNTEntities _db = new CAYCANHNTEntities();

        // GET: admin/Temp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CountContact()
        {
            var v = from t in _db.CONTACTs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult CountProduct()
        {
            var v = from t in _db.PRODUCTS
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult CountCart()
        {
            var v = from t in _db.ORDERs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult CountBlog()
        {
            var v = from t in _db.BLOGs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult CountMenu()
        {
            var v = from t in _db.MENUs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult CountCatology()
        {
            var v = from t in _db.CATOLOGies
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult CountSlider()
        {
            var v = from t in _db.SLIDERs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult CountUsers()
        {
            var v = from t in _db.USERS
                    select t;
            return PartialView(v.ToList());
        }
    }
}