using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAYCANHNT.Models;

namespace CAYCANHNT.Controllers
{
    public class SkinController : Controller
    {
        CAYCANHNTEntities db = new CAYCANHNTEntities();

        public ActionResult getLogo()
        {
            var v = from t in db.SKINs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getComercial()
        {
            var v = from t in db.SKINs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getGGMapHome()
        {
            var v = from t in db.SKINs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getFanpage()
        {
            var v = from t in db.SKINs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getFooter()
        {
            var v = from t in db.SKINs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getYoutube()
        {
            var v = from t in db.SKINs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getAboutUs()
        {
            var v = from t in db.SKINs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getGGMapAbout()
        {
            var v = from t in db.SKINs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getShopInfo()
        {
            var v = from t in db.SKINs
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getDeliveryInfo()
        {
            var v = from t in db.SKINs
                    select t;
            return PartialView(v.ToList());
        }
    }
}