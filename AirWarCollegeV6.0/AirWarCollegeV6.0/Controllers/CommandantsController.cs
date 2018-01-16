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
    public class CommandantsController : Controller
    {
        private AirWarCollege db = new AirWarCollege();
        public ActionResult Admin()
        {
            return RedirectToAction("Logout", "Admin");
        }

        // GET: Commandants
        public ActionResult Index()
        {
            if (Session["userName"] != null)
            {
                return View(db.Commandants.ToList());
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Commandants/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Commandant commandant = db.Commandants.Find(id);
                if (commandant == null)
                {
                    return HttpNotFound();
                }
                return View(commandant);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Commandants/Create
        public ActionResult Create()
        {
            if (Session["userName"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Commandants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Commandant commandant, HttpPostedFileBase ImageFile)
        {
            if (Session["userName"] != null)
            {
                using (var ms = new MemoryStream())
                {
                    ImageFile.InputStream.CopyTo(ms);
                    commandant.Image = ms.ToArray();
                }
                if (ModelState.IsValid)
                {
                    db.Commandants.Add(commandant);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(commandant);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Commandants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Commandant commandant = db.Commandants.Find(id);
                if (commandant == null)
                {
                    return HttpNotFound();
                }
                return View(commandant);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Commandants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Commandant commandant, HttpPostedFileBase ImageFile)
        {
            if (Session["userName"] != null)
            {
                if (ImageFile != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        ImageFile.InputStream.CopyTo(ms);
                        commandant.Image = ms.ToArray();
                    }
                    if (ModelState.IsValid)
                    {
                        db.Entry(commandant).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {

                        db.Entry(commandant).State = EntityState.Modified;
                        db.Entry(commandant).Property(x => x.Image).IsModified = false;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                return View(commandant);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Commandants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Commandant commandant = db.Commandants.Find(id);
                if (commandant == null)
                {
                    return HttpNotFound();
                }
                return View(commandant);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Commandants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["userName"] != null)
            {
                Commandant commandant = db.Commandants.Find(id);
                db.Commandants.Remove(commandant);
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
