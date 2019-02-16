using CreativeBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativeBox.Controllers
{
    public class BaseController : Controller
    {
        public Boolean UserLoginStatus()
        {
            //if (ObjSession != null)
            if (System.Web.HttpContext.Current.Session["LoginUser"] != null)
            {
                return true;
            }
            else
            {
                //RedirectToAction("Index");
                return false;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            #region No need to check session

            string action = filterContext.RouteData.Values["action"].ToString();
            string controller = filterContext.RouteData.Values["controller"].ToString();

            if (controller == "User" && action == "Login")
            {
                base.OnActionExecuting(filterContext);
                return;
            }
            if (controller == "User" && action == "Logout")
            {
                base.OnActionExecuting(filterContext);
                return;
            }
            #endregion
            bool userId = UserLoginStatus();

            if (userId == false)
            {
                HttpSessionStateBase session = filterContext.HttpContext.Session;
                session.RemoveAll();
                session.Clear();
                session.Abandon();

                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "User" }, { "action", "Login" } });

                base.OnActionExecuting(filterContext);
            }
            else
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())  // For check partial view
                {
                    HttpCookie Partialview = new HttpCookie("Partialview");

                    if (userId == true)
                    {
                        Response.Cookies["isPartialviewLogin"].Value = "false"; // <--- strange!!!!
                        base.OnActionExecuting(filterContext);
                    }
                    else
                    {
                        //Response.Cookies["isPartialviewLogin"].Value = "true"; // <--- strange!!!!
                        //Response.Cookies.Add(Partialview);

                        HttpSessionStateBase session = filterContext.HttpContext.Session;
                        session.RemoveAll();
                        session.Clear();
                        session.Abandon();
                        filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                        //filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "Login" }, { "action", "eFiling" } });

                        base.OnActionExecuting(filterContext);
                    }
                }
                else
                {
                    if (userId != true)
                    {
                        HttpSessionStateBase session = filterContext.HttpContext.Session;
                        session.RemoveAll();
                        session.Clear();
                        session.Abandon();
                        filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                        //filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "Login" }, { "action", "eFiling" } });
                    }
                    base.OnActionExecuting(filterContext);
                }
            }
        }
    }
}