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
    public class AnnouncementsController : Controller
    {
        private AirWarCollege db = new AirWarCollege();
        public ActionResult Admin()
        {
            return RedirectToAction("Logout", "Admin");
        }

        // GET: Announcements
        public ActionResult Index()
        {
            if (Session["userName"] != null)
                return View(db.Announcements.ToList());
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Announcements/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Announcement announcement = db.Announcements.Find(id);
                if (announcement == null)
                {
                    return HttpNotFound();
                }
                return View(announcement);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Announcements/Create
        public ActionResult Create()
        {
            if (Session["userName"] != null)
                return View();
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,announcementText,announcementDate,expiresAt")] Announcement announcement)
        {
            if (Session["userName"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Announcements.Add(announcement);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(announcement);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Announcements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Announcement announcement = db.Announcements.Find(id);
                if (announcement == null)
                {
                    return HttpNotFound();
                }
                return View(announcement);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,announcementText,announcementDate,expiresAt")] Announcement announcement)
        {
            if (Session["userName"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(announcement).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(announcement);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Announcements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }
            else 
           return RedirectToAction("Logout", "Admin");
           }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
       {
            if (Session["userName"] != null)
            {
          Announcement announcement = db.Announcements.Find(id);
          db.Announcements.Remove(announcement);
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
