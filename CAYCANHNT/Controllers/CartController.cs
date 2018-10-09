using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAYCANHNT.Models;
using System.Web.Script.Serialization;
using Model.DAO;

namespace CAYCANHNT.Controllers
{
    public class CartController : Controller
    {
        CAYCANHNTEntities db = new CAYCANHNTEntities();

        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return View(list);
        }

        public ActionResult AddItem(int ProductId, int Quantity)
        {
            var product = db.PRODUCTS.Find(ProductId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID_PRO == ProductId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID_PRO == ProductId)
                        {
                            item.Quantity += Quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = Quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Quantity = Quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID_PRO == item.Product.ID_PRO);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID_PRO == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult Payment(string name)
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult Payment()
        {
            //var order = new Model.EF.ORDER();
            //order.DATEBEGIN = DateTime.Now;

            //try
            //{
            //    var id = new OrderDAO().Insert(order);
            //    var cart = (List<CartItem>)Session[CartSession];
            //    var detailDAO = new Model.DAO.OrderDetailDAO();
            //    decimal total = 0;
            //    foreach (var item in cart)
            //    {
            //        var orderDetail = new Model.EF.ORDER_DETAIL();
            //        orderDetail.ID_PRO = item.Product.ID_PRO;
            //        orderDetail.ID_CART = id;
            //        orderDetail.PRICE = item.Product.PRICE;
            //        orderDetail.SOLD_NUM = item.Quantity;
            //        detailDAO.Insert(orderDetail);

            //        total += (item.Product.PRICE.GetValueOrDefault(0) * item.Quantity);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    //ghi log
            //    throw ex;
            //    //return Redirect("/loi-thanh-toan");
            //}
            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}