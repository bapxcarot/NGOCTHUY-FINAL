using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CAYCANHNT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //-----------------
            routes.MapRoute("Product", "{type}/{meta}",
            new { controller = "Product", action = "Index", type = UrlParameter.Optional, meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "danh-muc" }
            },
            namespaces: new[] { "CAYCANHNT.Controllers" });
            //------------------
            routes.MapRoute("Contact", "{type}",
           new { controller = "Contact", action = "Index" },
           new RouteValueDictionary
           {
                { "type", "lien-he" }
           },
           namespaces: new[] { "CAYCANHNT.Controllers" });
            //----------------
            routes.MapRoute("AboutUs", "{type}",
          new { controller = "AboutUs", action = "Index" },
          new RouteValueDictionary
          {
                { "type", "ve-chung-toi" }
          },
          namespaces: new[] { "CAYCANHNT.Controllers" });
            //---------------
            routes.MapRoute("Detail", "{type}/{meta}-{id}",
            new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "san-pham" }
            },
            namespaces: new[] { "CAYCANHNT.Controllers" });
            //-------------
            routes.MapRoute("Shop", "{type}",
          new { controller = "Shop", action = "Index" },
          new RouteValueDictionary
          {
                { "type", "cua-hang" }
          },
          namespaces: new[] { "CAYCANHNT.Controllers" });
            //----------------
            routes.MapRoute("News", "{type}",
          new { controller = "News", action = "Index" },
          new RouteValueDictionary
          {
                { "type", "tin-tuc" }
          },
          namespaces: new[] { "CAYCANHNT.Controllers" });
            //---------------
            routes.MapRoute("Login", "{type}",
          new { controller = "User", action = "Login" },
          new RouteValueDictionary
          {
                { "type", "dang-nhap" }
          },
          namespaces: new[] { "CAYCANHNT.Controllers" });
            //--------------
            routes.MapRoute("Logout", "{type}",
          new { controller = "User", action = "Logout" },
          new RouteValueDictionary
          {
                { "type", "thoat" }
          },
          namespaces: new[] { "CAYCANHNT.Controllers" });
            //------------
            routes.MapRoute("Register", "{type}",
          new { controller = "User", action = "Register" },
          new RouteValueDictionary
          {
                { "type", "dang-ky" }
          },
          namespaces: new[] { "CAYCANHNT.Controllers" });
            //-------------
            routes.MapRoute("DetailNews", "{type}/{meta}-{id}",
            new { controller = "News", action = "Detail", id = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "chi-tiet-bai-viet" }
            },
            namespaces: new[] { "CAYCANHNT.Controllers" });
            //-------------
            routes.MapRoute("InsertCart", "{type}",
            new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "them-gio-hang" }
            },
            namespaces: new[] { "CAYCANHNT.Controllers" });
            //-------------
            routes.MapRoute("Cart", "{type}",
           new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
           new RouteValueDictionary
           {
                { "type", "gio-hang" }
           },
           namespaces: new[] { "CAYCANHNT.Controllers" });
            //-------------
            routes.MapRoute("Payment", "{type}",
          new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
          new RouteValueDictionary
          {
                { "type", "thanh-toan" }
          },
          namespaces: new[] { "CAYCANHNT.Controllers" });
            //-------------
            routes.MapRoute("PaymentSuccess", "{type}",
          new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
          new RouteValueDictionary
          {
                { "type", "hoan-thanh" }
          },
          namespaces: new[] { "CAYCANHNT.Controllers" });
            //-------------
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "CAYCANHNT.Controllers" }
            );
        }
    }
}
