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
    public class SLIDERsController : Controller
    {
        private CAYCANHNTEntities db = new CAYCANHNTEntities();

        // GET: admin/SLIDERs
        public ActionResult Index()
        {
            return View(db.SLIDERs.ToList());
        }

        // GET: admin/SLIDERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLIDER sLIDER = db.SLIDERs.Find(id);
            if (sLIDER == null)
            {
                return HttpNotFound();
            }
            return View(sLIDER);
        }

        // GET: admin/SLIDERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/SLIDERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID_SLIDE,TITLE,IMG,DATEBEGIN,META,ORDER,LINK,HIDE")] SLIDER sLIDER, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                var date = DateTime.Now.ToString(); // get datetime at present
                date = date.Replace(" ", "_");      // replace space by _
                date = date.Replace("/", "_");      // replace / by _
                date = date.Replace(":", "_");      // replace : by _
                date = date + "_";                  // insert character _ in the end of string
                sLIDER.META = Help.Functions.ConvertToUnSign(sLIDER.TITLE);
                sLIDER.DATEBEGIN = DateTime.Now;
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        filename = date + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/images/slider"), filename);
                        img.SaveAs(path);
                        sLIDER.IMG = filename;
                    }
                    db.SLIDERs.Add(sLIDER);
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
            return View(sLIDER);
        }

        // GET: admin/SLIDERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLIDER sLIDER = db.SLIDERs.Find(id);
            if (sLIDER == null)
            {
                return HttpNotFound();
            }
            return View(sLIDER);
        }

        // POST: admin/SLIDERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID_SLIDE,TITLE,IMG,DATEBEGIN,META,ORDER,LINK,HIDE")] SLIDER sLIDER, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                var date = DateTime.Now.ToString(); // get datetime at present
                date = date.Replace(" ", "_");      // replace space by _
                date = date.Replace("/", "_");      // replace / by _
                date = date.Replace(":", "_");      // replace : by _
                date = date + "_";                  // insert character _ in the end of string
                sLIDER.META = Help.Functions.ConvertToUnSign(sLIDER.TITLE);
                sLIDER.DATEBEGIN = DateTime.Now;
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        filename = date + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/images/slider"), filename);
                        img.SaveAs(path);
                        sLIDER.IMG = filename;
                    }
                    db.Entry(sLIDER).State = EntityState.Modified;
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
            return View(sLIDER);
        }

        // GET: admin/SLIDERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLIDER sLIDER = db.SLIDERs.Find(id);
            if (sLIDER == null)
            {
                return HttpNotFound();
            }
            return View(sLIDER);
        }

        // POST: admin/SLIDERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SLIDER sLIDER = db.SLIDERs.Find(id);
            db.SLIDERs.Remove(sLIDER);
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
