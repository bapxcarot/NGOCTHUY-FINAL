using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAYCANHNT.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Send(string name, string email, string title, string detail)
        {
            var contact = new CONTACT
            {
                datebegin = DateTime.Now,
                username = name,
                email = email,
                title = title,
                detail = detail
            };

            var id = new ContactDAO().InsertContact(contact);
            if (id > 0)
                return Json(new
                {
                    status = true
                });
            else
                return Json(new
                {
                    status = false
                });
        }
    }
}