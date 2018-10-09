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
    public class PRODUCTsController : Controller
    {
        private CAYCANHNTEntities db = new CAYCANHNTEntities();

        public bool BoolValue
        {
            get { return IntValue == 1; }
            set { IntValue = value ? 1 : 0; }
        }

        public int IntValue { get; set; }

        // GET: admin/PRODUCTs
        public ActionResult Index(long? id = null)
        {
            //var pRODUCTS = db.PRODUCTS.Include(p => p.CATOLOGY);
            //return View(pRODUCTS.ToList());
            getCatogory(id);
            //return View(db.products.ToList());
            return View();
        }

        public void getCatogory(long? selectedId = null)
        {
            ViewBag.Catogory = new SelectList(db.CATOLOGies.Where(x => x.HIDE == 0)
                .OrderBy(x => x.ORDER), "ID_CAT", "NAME_CAT", selectedId);
        }

        public ActionResult getProduct(long? id)
        {
            if (id == null)
            {
                var v = db.PRODUCTS.OrderBy(x => x.ORDER).ToList();
                return PartialView(v);
            }
            var m = db.PRODUCTS.Where(x => x.ID_CAT == id).OrderBy(x => x.ORDER).ToList();
            return PartialView(m);
        }

        // GET: admin/product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT product = db.PRODUCTS.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: admin/PRODUCTs/Create
        public ActionResult Create()
        {
            ViewBag.ID_CAT = new SelectList(db.CATOLOGies, "ID_CAT", "NAME_CAT");
            return View();
        }

        // POST: admin/PRODUCTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID_PRO,NAME_PRO,NUMS,PRICE,DETAIL,IMG1,IMG2,IMG3,META,ORDER,LINK,HIDE,ID_CAT")] PRODUCT pRODUCT, HttpPostedFileBase img1, HttpPostedFileBase img2, HttpPostedFileBase img3)
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
                ViewBag.ID_CAT = new SelectList(db.CATOLOGies, "ID_CAT", "NAME_CAT", pRODUCT.ID_CAT);
                if (ModelState.IsValid)
                {
                    if (img1 != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = date + img1.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/product"), filename);
                        img1.SaveAs(path);
                        pRODUCT.IMG1 = filename;
                    }
                    if (img2 != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = date + img2.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/product"), filename);
                        img2.SaveAs(path);
                        pRODUCT.IMG2 = filename;
                    }
                    if (img3 != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = date + img3.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/product"), filename);
                        img3.SaveAs(path);
                        pRODUCT.IMG3 = filename;
                    }
                    if (img1 == null)
                    {
                        pRODUCT.IMG1 = "default-img.jpg";
                    }
                    if (img2 == null)
                    {
                        pRODUCT.IMG2 = "default-img.jpg";
                    }
                    if (img3 == null)
                    {
                        pRODUCT.IMG3 = "default-img.jpg";
                    }
                    pRODUCT.META = Help.Functions.ConvertToUnSign(pRODUCT.NAME_PRO);
                    db.PRODUCTS.Add(pRODUCT);
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
            return View(pRODUCT);
        }

        // GET: admin/PRODUCTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CAT = new SelectList(db.CATOLOGies, "ID_CAT", "NAME_CAT", pRODUCT.ID_CAT);
            return View(pRODUCT);
        }

        // POST: admin/PRODUCTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID_PRO,NAME_PRO,NUMS,PRICE,DETAIL,IMG1,IMG2,IMG3,META,ORDER,LINK,HIDE,ID_CAT")] PRODUCT pRODUCT, HttpPostedFileBase img1, HttpPostedFileBase img2, HttpPostedFileBase img3)
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
                ViewBag.ID_CAT = new SelectList(db.CATOLOGies, "ID_CAT", "NAME_CAT", pRODUCT.ID_CAT);
                if (ModelState.IsValid)
                {
                    if (img1 != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = date + img1.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/product"), filename);
                        img1.SaveAs(path);
                        pRODUCT.IMG1 = filename;
                    }
                    if (img2 != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = date + img2.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/product"), filename);
                        img2.SaveAs(path);
                        pRODUCT.IMG2 = filename;
                    }
                    if (img3 != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = date + img3.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/product"), filename);
                        img3.SaveAs(path);
                        pRODUCT.IMG3 = filename;
                    }
                    if (img1 == null)
                    {
                        pRODUCT.IMG1 = "default-img.jpg";
                    }
                    if (img2 == null)
                    {
                        pRODUCT.IMG2 = "default-img.jpg";
                    }
                    if (img3 == null)
                    {
                        pRODUCT.IMG3 = "default-img.jpg";
                    }
                    pRODUCT.META = Help.Functions.ConvertToUnSign(pRODUCT.NAME_PRO);
                    db.Entry(pRODUCT).State = EntityState.Modified;
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
            return View(pRODUCT);
        }

        // GET: admin/PRODUCTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: admin/PRODUCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            db.PRODUCTS.Remove(pRODUCT);
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
