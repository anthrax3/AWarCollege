using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirWarCollegeV6._0.Models;


namespace AirWarCollegeV6._0.Controllers
{

    public class AdminController : Controller
    {
        [System.Web.Mvc.OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        // GET: Admin
        public ActionResult Index(Admin admin)
        {
            string u = admin.userName;
            string p = admin.password;
            if (ModelState.IsValid)
            {
                    AirWarCollege db = new AirWarCollege();
                    var log = db.Admins.Where(a => a.userName.Equals(u) && a.password.Equals(p)).FirstOrDefault();
                    if (log != null)
                    {
                        Session["userName"] = log.userName;
                        return RedirectToAction("Index", "AdminActions");
                    }
                    else if (admin.password.Length <= 6)
                    {
                        Response.Write("<script>alert('Invalid username or password')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid username or password')</script>");
                    }
                }           
            return View();
        }
        [System.Web.Mvc.OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Logout()
        {
            HttpContext.Response.Cookies.Set(new HttpCookie("cookie_name") { Value = string.Empty });
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index", "Admin");

        }
    }
}