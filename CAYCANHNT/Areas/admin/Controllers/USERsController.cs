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
using CAYCANHNT.Common;

namespace CAYCANHNT.Areas.admin.Controllers
{
    public class USERsController : Controller
    {
        private CAYCANHNTEntities db = new CAYCANHNTEntities();

        // GET: admin/USERs
        public ActionResult Index()
        {
            return View(db.USERS.ToList());
        }

        // GET: admin/USERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USERS.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }

        // GET: admin/USERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/USERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID_USERS,USERNAME,PASSWORD,NAME,ADDRESS,EMAIL,PHONE,PERMISSION,META,ORDER,LINK,HIDE")] USER uSER)
        {
            try
            {
                uSER.PASSWORD = Common.Encryptor.MD5Hash(uSER.PASSWORD);
                uSER.META = Help.Functions.ConvertToUnSign(uSER.NAME);
                uSER.ORDER = null;
                if (ModelState.IsValid)
                {
                    db.USERS.Add(uSER);
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
            return View(uSER);
        }

        // GET: admin/USERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USERS.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }

        // POST: admin/USERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID_USERS,USERNAME,PASSWORD,NAME,ADDRESS,EMAIL,PHONE,PERMISSION,META,ORDER,LINK,HIDE")] USER uSER)
        {
            try
            {
                uSER.PASSWORD = Common.Encryptor.MD5Hash(uSER.PASSWORD);
                uSER.META = Help.Functions.ConvertToUnSign(uSER.NAME);
                uSER.ORDER = null;
                if (ModelState.IsValid)
                {
                    db.Entry(uSER).State = EntityState.Modified;
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
            return View(uSER);
        }

        // GET: admin/USERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USERS.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }

        // POST: admin/USERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USER uSER = db.USERS.Find(id);
            db.USERS.Remove(uSER);
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
