using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirWarCollegeV6._0.Models;
using System.IO;
namespace AirWarCollege3._2.Controllers
{
    public class HomeController : Controller
    {

        private AirWarCollege db = new AirWarCollege();
      
        public ActionResult Index()
        {
            ViewModel mymodel = new ViewModel();
            mymodel.Announcement = db.Announcements.ToList();
            mymodel.cyberAlert = db.cyberAlerts.ToList();
            return View(mymodel);
        }

       public ActionResult AlumniInUI()
        {
            return View(db.Alumni.ToList());
        }
        public ActionResult CommandantsInUI()
        {
            return View(db.Commandants.ToList());
        }
        public ActionResult HistoryofAWC()
        {
            return View();
        } 
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult TrainingFacilities()
        {
            return View();
        }
        public ActionResult ITFacilities()
        {
            return View();
        }
        public ActionResult Library()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Study_Material()
        {
            return View(db.Study_Materials.ToList());
        }
        // POST: Study_Material/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        public ActionResult CreateStudy()
        {
                return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStudy(Study_Material study_Material, HttpPostedFileBase fileUpload)
        {

            using (var ms = new MemoryStream())
            {
                fileUpload.InputStream.CopyTo(ms);
                study_Material.File = ms.ToArray();
            }
            if (ModelState.IsValid)
            {
                db.Study_Materials.Add(study_Material);
                db.SaveChanges();
                return RedirectToAction("Study_Material");
            }

            return View(study_Material);
        }
        public ActionResult CreateSynopsis()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult CreateSynopsis(Synopsis synopsis, HttpPostedFileBase fileUpload)
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
                return RedirectToAction("Synopses");
            }

            return View(synopsis);
        }
        public ActionResult Synopses()
        {
            return View(db.Synopsis.ToList());
        }
        }

    }
