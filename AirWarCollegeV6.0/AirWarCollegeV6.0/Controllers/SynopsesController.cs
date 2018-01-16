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
    public class SynopsesController : Controller
    {
        private AirWarCollege db = new AirWarCollege();
        public ActionResult Admin()
        {
            return RedirectToAction("Logout", "Admin");
        }

        // GET: Synopses
        public ActionResult Index()
        {
            if (Session["userName"] != null)
            {
                return View(db.Synopsis.ToList());
            }
            else
                return RedirectToAction("Logout", "Admin");
        }
        public FileContentResult Download(int id)
        {
            var file = db.Study_Materials.Where(f => f.Id == id).SingleOrDefault();
            var fileRes = new FileContentResult(file.File.ToArray(), "application/octet-stream");
            fileRes.FileDownloadName = file.FileName;
            return fileRes;
        }


        // GET: Synopses/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Synopsis synopsis = db.Synopsis.Find(id);
                if (synopsis == null)
                {
                    return HttpNotFound();
                }
                return View(synopsis);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Synopses/Create
        public ActionResult Create()
        {
            if (Session["userName"] != null)
                return View();
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Synopses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Synopsis synopsis, HttpPostedFileBase fileUpload)
        {
            if (Session["userName"] != null)
            {
                using (var ms = new MemoryStream())
                {
                    fileUpload.InputStream.CopyTo(ms);
                    synopsis.File = ms.ToArray();
                }
                if (ModelState.IsValid)
                {
                    db.Synopsis.Add(synopsis);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(synopsis);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Synopses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Synopsis synopsis = db.Synopsis.Find(id);
                if (synopsis == null)
                {
                    return HttpNotFound();
                }
                return View(synopsis);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Synopses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Synopsis synopsis,HttpPostedFileBase fileUpload)
        {
            if (Session["userName"] != null)
            {
                if (fileUpload != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        fileUpload.InputStream.CopyTo(ms);
                        synopsis.File = ms.ToArray();
                    }
                    if (ModelState.IsValid)
                    {
                        db.Entry(synopsis).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                return View(synopsis);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Synopses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Synopsis synopsis = db.Synopsis.Find(id);
                if (synopsis == null)
                {
                    return HttpNotFound();
                }
                return View(synopsis);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Synopses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["userName"] != null)
            {
                Synopsis synopsis = db.Synopsis.Find(id);
                db.Synopsis.Remove(synopsis);
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
