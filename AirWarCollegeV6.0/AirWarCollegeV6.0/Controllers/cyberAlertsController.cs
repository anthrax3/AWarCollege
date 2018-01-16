using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirWarCollegeV6._0.Models;

namespace AirWarCollegeV6._0.Controllers
{
    public class cyberAlertsController : Controller
    {
        private AirWarCollege db = new AirWarCollege();
        public ActionResult Admin()
        {
            return RedirectToAction("Logout", "Admin");
        }

        // GET: cyberAlerts
        public ActionResult Index()
        {
            if (Session["userName"] != null)
            {
                return View(db.cyberAlerts.ToList());
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: cyberAlerts/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                cyberAlert cyberAlert = db.cyberAlerts.Find(id);
                if (cyberAlert == null)
                {
                    return HttpNotFound();
                }
                return View(cyberAlert);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: cyberAlerts/Create
        public ActionResult Create()
        {
            if (Session["userName"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: cyberAlerts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,cyberAlertText,cyberAlertDate,expiresAt")] cyberAlert cyberAlert)
        {
            if (Session["userName"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.cyberAlerts.Add(cyberAlert);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(cyberAlert);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: cyberAlerts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                cyberAlert cyberAlert = db.cyberAlerts.Find(id);
                if (cyberAlert == null)
                {
                    return HttpNotFound();
                }
                return View(cyberAlert);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: cyberAlerts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,cyberAlertText,cyberAlertDate,expiresAt")] cyberAlert cyberAlert)
        {
            if (Session["userName"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cyberAlert).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cyberAlert);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: cyberAlerts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                cyberAlert cyberAlert = db.cyberAlerts.Find(id);
                if (cyberAlert == null)
                {
                    return HttpNotFound();
                }
                return View(cyberAlert);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: cyberAlerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["userName"] != null)
            {
                cyberAlert cyberAlert = db.cyberAlerts.Find(id);
                db.cyberAlerts.Remove(cyberAlert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Logout", "Admin");
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
