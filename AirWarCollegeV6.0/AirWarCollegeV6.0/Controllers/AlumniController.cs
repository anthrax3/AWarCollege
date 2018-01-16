using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using AirWarCollegeV6._0.Models;

namespace AirWarCollegeV6._0.Controllers
{
    public class AlumniController : Controller
    {
        private AirWarCollege db = new AirWarCollege();
        public ActionResult Admin()
        {
            return RedirectToAction("Logout", "Admin");
        }
        // GET: Alumni
        public ActionResult Index()
        {
            if (Session["userName"] != null) 
                return View(db.Alumni.ToList());
            else 
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Alumni/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Alumnus alumnus = db.Alumni.Find(id);
                if (alumnus == null)
                {
                    return HttpNotFound();
                }
                return View(alumnus);
            }
            else
                return RedirectToAction("Logout", "Admin");

        }

        // GET: Alumni/Create
        public ActionResult Create()
        {
            if (Session["userName"] != null)
                return View();
                        else 
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Alumni/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alumnus alumnus, HttpPostedFileBase ImageFile)
        {
            if (Session["userName"] != null)
            {
                using (var ms = new MemoryStream())
                {
                    ImageFile.InputStream.CopyTo(ms);
                    alumnus.Image = ms.ToArray();
                }
                if (ModelState.IsValid)
                {
                    db.Alumni.Add(alumnus);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(alumnus);
            }

            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Alumni/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["userName"] != null)
            {


                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Alumnus alumnus = db.Alumni.Find(id);
                if (alumnus == null)
                {
                    return HttpNotFound();
                }
                return View(alumnus);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Alumni/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Alumnus alumnus, HttpPostedFileBase ImageFile)
        {
            if (Session["userName"] != null)
            {
                if (ImageFile != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        ImageFile.InputStream.CopyTo(ms);
                        alumnus.Image = ms.ToArray();
                    }
                    if (ModelState.IsValid)
                    {
                        db.Entry(alumnus).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        alumnus.Name = alumnus.Name;
                        db.Entry(alumnus).State = EntityState.Modified;
                        db.Entry(alumnus).Property(x => x.Image).IsModified = false;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }

                return View(alumnus);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Alumni/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Alumnus alumnus = db.Alumni.Find(id);
                if (alumnus == null)
                {
                    return HttpNotFound();
                }
                return View(alumnus);
            }

            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Alumni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["userName"] != null)
            {
                Alumnus alumnus = db.Alumni.Find(id);
                db.Alumni.Remove(alumnus);
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
