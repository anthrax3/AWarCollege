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
    public class Study_MaterialController : Controller
    {
        private AirWarCollege db = new AirWarCollege();
        public ActionResult Admin()
        {
            return RedirectToAction("Logout", "Admin");
        }

        // GET: Study_Material
        public ActionResult Index()
        {
            if (Session["userName"] != null)
                return View(db.Study_Materials.ToList());
            else
                return RedirectToAction("Logout", "Admin");
        }
        //public FileContentResult ViewFile(int id)
        //{
        //    if (id == 0) { return null; }
        //    Study_Material upload= new Study_Material();

        //    upload = db.Study_Materials.Where(a => a.Id == id).SingleOrDefault();
        //    Response.AppendHeader("content-disposition", "inline; filename=file.pdf"); //this will open in a new tab.. remove if you want to open in the same tab.
        //    return File(upload.File, "application/pdf");
        //}
        //public FileContentResult Download(int id)
        //{

        //    var file = db.Study_Materials.Where(f => f.Id == id).SingleOrDefault() ;
        //    var fileRes = new FileContentResult(file.File.ToArray(), "application/octet-stream");
        //    fileRes.FileDownloadName = file.FileName;
        //    return fileRes;

        //}

        public FileResult Download(int id)
        {
            var file = db.Study_Materials.Where(f => f.Id == id).SingleOrDefault();
            var fileRes = new FileContentResult(file.File.ToArray(), "application/octet-stream/pdf");
            fileRes.FileDownloadName = file.FileName;
            return fileRes;
        }

        // GET: Study_Material/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Study_Material study_Material = db.Study_Materials.Find(id);
                if (study_Material == null)
                {
                    return HttpNotFound();
                }

                return View(study_Material);
            }
            else
                return RedirectToAction("Logout", "Admin");

        }

        // GET: Study_Material/Create
        public ActionResult Create()
        {
            if (Session["userName"] != null)
                return View();
            else
                return RedirectToAction("Logout", "Admin");
        }
      // POST: Study_Material/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Study_Material study_Material, HttpPostedFileBase fileUpload)
        {
            if (Session["userName"] != null)
            {
                //var extension = Path.GetExtension(fileUpload.FileName);
                using (var ms = new MemoryStream())
                {
                    fileUpload.InputStream.CopyTo(ms);
                    study_Material.File = ms.ToArray();
                }
                if (ModelState.IsValid)
                {
                    db.Study_Materials.Add(study_Material);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(study_Material);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Study_Material/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Study_Material study_Material = db.Study_Materials.Find(id);
                if (study_Material == null)
                {
                    return HttpNotFound();
                }
                return View(study_Material);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Study_Material/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Study_Material study_Material ,HttpPostedFileBase fileUpload)
        {
            if (Session["userName"] != null)
            {
                if (fileUpload != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        fileUpload.InputStream.CopyTo(ms);
                        study_Material.File = ms.ToArray();
                    }
                    if (ModelState.IsValid)
                    {
                        db.Entry(study_Material).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                return View(study_Material);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Study_Material/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["userName"] != null)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Study_Material study_Material = db.Study_Materials.Find(id);
                if (study_Material == null)
                {
                    return HttpNotFound();
                }
                return View(study_Material);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Study_Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["userName"] != null)
            {
                Study_Material study_Material = db.Study_Materials.Find(id);
                db.Study_Materials.Remove(study_Material);
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
