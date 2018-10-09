using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAYCANHNT.Models;

namespace CAYCANHNT.Controllers
{
    public class NewsController : Controller
    {
        CAYCANHNTEntities _db = new CAYCANHNTEntities();

        // GET: News
        public ActionResult Index()
        {
            var v = from t in _db.BLOGs
                    where t.HIDE == 0
                    orderby t.ORDER descending
                    select t;
            return View(v.ToList());
        }

        public ActionResult Detail(long id)
        {
            var v = from t in _db.BLOGs
                    where t.ID_BLOG == id
                    select t;
            return View(v.FirstOrDefault());
        }
    }
}