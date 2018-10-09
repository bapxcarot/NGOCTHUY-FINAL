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
    public class MENUsController : Controller
    {
        private CAYCANHNTEntities db = new CAYCANHNTEntities();

        // GET: admin/MENUs
        public ActionResult Index()
        {
            return View(db.MENUs.ToList());
        }

        // GET: admin/MENUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = db.MENUs.Find(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            return View(mENU);
        }

        // GET: admin/MENUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/MENUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID_MENU,TITLE,DATEBEGIN,META,ORDER,LINK,HIDE")] MENU mENU)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mENU.DATEBEGIN = DateTime.Now;
                    mENU.META = Help.Functions.ConvertToUnSign(mENU.TITLE);
                    db.MENUs.Add(mENU);
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
            return View(mENU);
        }

        // GET: admin/MENUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = db.MENUs.Find(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            return View(mENU);
        }

        // POST: admin/MENUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID_MENU,TITLE,DATEBEGIN,META,ORDER,LINK,HIDE")] MENU mENU)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mENU.DATEBEGIN = DateTime.Now;
                    mENU.META = Help.Functions.ConvertToUnSign(mENU.TITLE);
                    db.Entry(mENU).State = EntityState.Modified;
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
            return View(mENU);
        }

        // GET: admin/MENUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = db.MENUs.Find(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            return View(mENU);
        }

        // POST: admin/MENUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MENU mENU = db.MENUs.Find(id);
            db.MENUs.Remove(mENU);
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
