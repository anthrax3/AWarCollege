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
    public class QuotesController : Controller
    {
        private AirWarCollege db = new AirWarCollege();
        public ActionResult Admin()
        {
            return RedirectToAction("Logout", "Admin");
        }

        // GET: Quotes
        public ActionResult Index()
        {
            if (Session["userName"] != null)
            {
                return View(db.Quotes.ToList());
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Quotes/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Quote quote = db.Quotes.Find(id);
                if (quote == null)
                {
                    return HttpNotFound();
                }
                return View(quote);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Quotes/Create
        public ActionResult Create()
        {
            if (Session["userName"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,quoteText,expiresAt")] Quote quote)
        {
            if (Session["userName"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Quotes.Add(quote);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(quote);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Quotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Quote quote = db.Quotes.Find(id);
                if (quote == null)
                {
                    return HttpNotFound();
                }
                return View(quote);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,quoteText,expiresAt")] Quote quote)
        {
            if (Session["userName"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(quote).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(quote);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // GET: Quotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["userName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Quote quote = db.Quotes.Find(id);
                if (quote == null)
                {
                    return HttpNotFound();
                }
                return View(quote);
            }
            else
                return RedirectToAction("Logout", "Admin");
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["userName"] != null)
            {
                Quote quote = db.Quotes.Find(id);
                db.Quotes.Remove(quote);
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
