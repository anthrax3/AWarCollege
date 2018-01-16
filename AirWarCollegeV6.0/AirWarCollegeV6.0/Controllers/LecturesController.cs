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
    public class LecturesController : Controller
    {
        private AirWarCollege db = new AirWarCollege();
        public ActionResult Admin()
        {
            return RedirectToAction("Logout", "Admin");
        }

        // GET: Lectures
        public ActionResult Index()
        {
            if (Session["userName"] != null)
            {
                return View(db.Lectures.ToList());
            }
            else
                return RedirectToAction("Logout", "Admin");

        }

        // GET: Lectures/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Lecture lecture = db.Lectures.Find(id);
                if (lecture == null)
                {
                    return HttpNotFound();
                }
                return View(lecture);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Lectures/Create
        public ActionResult Create()
        {
            if (Session["userName"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Lectures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,lectureTopic,speakerName,location,date")] Lecture lecture)
        {
            if (Session["userName"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Lectures.Add(lecture);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(lecture);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Lectures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Lecture lecture = db.Lectures.Find(id);
                if (lecture == null)
                {
                    return HttpNotFound();
                }
                return View(lecture);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,lectureTopic,speakerName,location,date")] Lecture lecture)
        {
            if (Session["userName"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(lecture).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(lecture);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Lectures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Lecture lecture = db.Lectures.Find(id);
                if (lecture == null)
                {
                    return HttpNotFound();
                }
                return View(lecture);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["userName"] != null)
            {
                Lecture lecture = db.Lectures.Find(id);
                db.Lectures.Remove(lecture);
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
