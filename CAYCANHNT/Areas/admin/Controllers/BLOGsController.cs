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
    public class BLOGsController : Controller
    {
        private CAYCANHNTEntities db = new CAYCANHNTEntities();

        // GET: admin/BLOGs
        public ActionResult Index()
        {
            var bLOGs = db.BLOGs.Include(b => b.USER);
            return View(bLOGs.ToList());
        }

        // GET: admin/BLOGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            return View(bLOG);
        }

        // GET: admin/BLOGs/Create
        public ActionResult Create()
        {
            ViewBag.ID_USERS = new SelectList(db.USERS, "ID_USERS", "USERNAME");
            return View();
        }

        // POST: admin/BLOGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID_BLOG,TITLE,IMG,DETAIL,DATEBEGIN,META,ORDER,LINK,HIDE,ID_USERS,DESCRIPTION")] BLOG bLOG, HttpPostedFileBase img)
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

                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        filename = date + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/news"), filename);
                        img.SaveAs(path);
                        bLOG.IMG = filename;
                    }
                    bLOG.DATEBEGIN = DateTime.Now;
                    bLOG.META = Help.Functions.ConvertToUnSign(bLOG.TITLE);
                    db.BLOGs.Add(bLOG);
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
            ViewBag.ID_USERS = new SelectList(db.USERS, "ID_USERS", "USERNAME", bLOG.ID_USERS);
            return View(bLOG);
        }

        // GET: admin/BLOGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_USERS = new SelectList(db.USERS, "ID_USERS", "USERNAME", bLOG.ID_USERS);
            return View(bLOG);
        }

        // POST: admin/BLOGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID_BLOG,TITLE,IMG,DETAIL,DATEBEGIN,META,ORDER,LINK,HIDE,ID_USERS,DESCRIPTION")] BLOG bLOG, HttpPostedFileBase img)
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

                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        filename = date + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/news"), filename);
                        img.SaveAs(path);
                        bLOG.IMG = filename;
                    }
                    bLOG.DATEBEGIN = DateTime.Now;
                    bLOG.META = Help.Functions.ConvertToUnSign(bLOG.TITLE);
                    db.Entry(bLOG).State = EntityState.Modified;
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
            ViewBag.ID_USERS = new SelectList(db.USERS, "ID_USERS", "USERNAME", bLOG.ID_USERS);
            return View(bLOG);
        }

        // GET: admin/BLOGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            return View(bLOG);
        }

        // POST: admin/BLOGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BLOG bLOG = db.BLOGs.Find(id);
            db.BLOGs.Remove(bLOG);
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
