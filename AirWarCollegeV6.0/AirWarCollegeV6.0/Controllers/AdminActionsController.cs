using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirWarCollegeV6._0.Controllers
{
    public class AdminActionsController : Controller
    {
        // GET: AdminActions 
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
        public ActionResult Index()
        {
            if (Session["userName"] != null)
                return View();
            else
                return RedirectToAction("Logout", "Admin");
        }
    }
}