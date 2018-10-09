using CAYCANHNT.Common;
using CAYCANHNT.Models;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAYCANHNT.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin
                    {
                        UserName = user.USERNAME,
                        UserID = user.ID_USERS,
                        Permission = (int)user.PERMISSION
                    };
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    if (user.PERMISSION == 1)
                    {
                        return Redirect("/admin/temp"); //neu la admin
                    }
                    return Redirect("/"); // ve trang chu
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
            return View(model);
        }

        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại!");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email này đã được sửa dụng!");
                }
                else
                {
                    var user = new Model.EF.USER
                    {
                        USERNAME = model.UserName,
                        PASSWORD = Common.Encryptor.MD5Hash(model.PassWord),
                        NAME = model.Name,
                        ADDRESS = model.Address,
                        EMAIL = model.Email,
                        PHONE = model.Phone,
                        PERMISSION = 0,
                        META = Help.Functions.ConvertToUnSign(model.UserName),
                        HIDE = 0,
                        LINK = model.Link
                    };
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        ModelState.Clear();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công!");
                    }
                }
            }
            return View(model);
        }
    }
}