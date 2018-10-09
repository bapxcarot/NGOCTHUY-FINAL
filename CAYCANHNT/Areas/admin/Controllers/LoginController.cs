using CAYCANHNT.Areas.admin.Models;
using Model.DAO;
using CAYCANHNT.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAYCANHNT.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    if (user.PERMISSION == 1)
                    {
                        var userSession = new UserLogin
                        {
                            UserName = user.USERNAME,
                            UserID = user.ID_USERS,
                            Permission = (int)user.PERMISSION
                        };
                        Session.Add(CommonConstant.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Temp");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bạn không có quyền truy cập!");
                    }
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng!");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng!");
                }
            }
            return View("Index");
        }
    }
}