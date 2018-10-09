using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CAYCANHNT.Models;

namespace CAYCANHNT.Areas.admin.Controllers
{
    public class CATOLOGiesController : Controller
    {
        private CAYCANHNTEntities db = new CAYCANHNTEntities();

        // GET: admin/CATOLOGies
        public ActionResult Index()
        {
            return View(db.CATOLOGies.ToList());
        }

        // GET: admin/CATOLOGies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATOLOGY cATOLOGY = db.CATOLOGies.Find(id);
            if (cATOLOGY == null)
            {
                return HttpNotFound();
            }
            return View(cATOLOGY);
        }

        // GET: admin/CATOLOGies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/CATOLOGies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID_CAT,NAME_CAT,META,ORDER,LINK,HIDE")] CATOLOGY cATOLOGY)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cATOLOGY.META = Help.Functions.ConvertToUnSign(cATOLOGY.NAME_CAT);
                    db.CATOLOGies.Add(cATOLOGY);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(cATOLOGY);
        }

        // GET: admin/CATOLOGies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATOLOGY cATOLOGY = db.CATOLOGies.Find(id);
            if (cATOLOGY == null)
            {
                return HttpNotFound();
            }
            return View(cATOLOGY);
        }

        // POST: admin/CATOLOGies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID_CAT,NAME_CAT,META,ORDER,LINK,HIDE")] CATOLOGY cATOLOGY)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cATOLOGY.META = Help.Functions.ConvertToUnSign(cATOLOGY.NAME_CAT);
                    db.Entry(cATOLOGY).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(cATOLOGY);
        }

        // GET: admin/CATOLOGies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATOLOGY cATOLOGY = db.CATOLOGies.Find(id);
            if (cATOLOGY == null)
            {
                return HttpNotFound();
            }
            return View(cATOLOGY);
        }

        // POST: admin/CATOLOGies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATOLOGY cATOLOGY = db.CATOLOGies.Find(id);
            db.CATOLOGies.Remove(cATOLOGY);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
