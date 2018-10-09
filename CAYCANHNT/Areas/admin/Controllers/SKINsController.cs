using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CAYCANHNT.Models;

namespace CAYCANHNT.Areas.admin.Controllers
{
    public class SKINsController : Controller
    {
        private CAYCANHNTEntities db = new CAYCANHNTEntities();

        // GET: admin/SKINs
        public ActionResult Index()
        {
            return View(db.SKINs.ToList());
        }

        // GET: admin/SKINs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SKIN sKIN = db.SKINs.Find(id);
            if (sKIN == null)
            {
                return HttpNotFound();
            }
            return View(sKIN);
        }

        // GET: admin/SKINs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/SKINs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,logo,comercial,comercial_link,googlemap,fanpage,footer,youtube,aboutus,shopinfo,deliveryinfo")] SKIN sKIN)
        {
            if (ModelState.IsValid)
            {
                db.SKINs.Add(sKIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sKIN);
        }

        // GET: admin/SKINs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SKIN sKIN = db.SKINs.Find(id);
            if (sKIN == null)
            {
                return HttpNotFound();
            }
            return View(sKIN);
        }

        // POST: admin/SKINs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,logo,comercial,comercial_link,googlemap,fanpage,footer,youtube,aboutus,shopinfo,deliveryinfo")] SKIN sKIN, HttpPostedFileBase logo, HttpPostedFileBase comercial)
        {
            try
            {
                var path = "";
                var filename = "";
                var date = DateTime.Now.ToString();
                date = date.Replace(" ", "_");
                date = date.Replace("/", "_");
                date = date.Replace(":", "_");
                date = date + "_";

                if (ModelState.IsValid)
                {
                    if (logo !=null)
                    {
                        filename = date + logo.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/images/"), filename);
                        logo.SaveAs(path);
                        sKIN.logo = filename;
                    }
                    if (comercial != null)
                    {
                        filename = date + comercial.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/images/"), filename);
                        comercial.SaveAs(path);
                        sKIN.comercial = filename;
                    }
                    db.Entry(sKIN).State = EntityState.Modified;
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
            return View(sKIN);
        }

        // GET: admin/SKINs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SKIN sKIN = db.SKINs.Find(id);
            if (sKIN == null)
            {
                return HttpNotFound();
            }
            return View(sKIN);
        }

        // POST: admin/SKINs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SKIN sKIN = db.SKINs.Find(id);
            db.SKINs.Remove(sKIN);
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
