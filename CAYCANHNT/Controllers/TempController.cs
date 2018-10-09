using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAYCANHNT.Models;

namespace CAYCANHNT.Controllers
{
    public class TempController : Controller
    {
        CAYCANHNTEntities _db = new CAYCANHNTEntities();
        // GET: Temp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getmenu()
        {
            var v = from t in _db.MENUs
                    where t.HIDE == 0
                    orderby t.ORDER ascending
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getcatolory()
        {
            var v = from t in _db.CATOLOGies
                    where t.HIDE == 0
                    orderby t.ORDER ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}