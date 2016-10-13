using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MDLinMVC.Models;

namespace MDLinMVC.Controllers
{
    public class RockBandsController : Controller
    {
        private MDLinMVCContext db = new MDLinMVCContext();

        // GET: RockBands
        public ActionResult Index()
        {
            return View(db.RockBands.ToList());
        }

        // GET: RockBands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RockBand rockBand = db.RockBands.Find(id);
            if (rockBand == null)
            {
                return HttpNotFound();
            }
            return View(rockBand);
        }

        // GET: RockBands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RockBands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,OriginationDate")] RockBand rockBand)
        {
            if (ModelState.IsValid)
            {
                db.RockBands.Add(rockBand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rockBand);
        }

        // GET: RockBands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RockBand rockBand = db.RockBands.Find(id);
            if (rockBand == null)
            {
                return HttpNotFound();
            }
            return View(rockBand);
        }

        // POST: RockBands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,OriginationDate")] RockBand rockBand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rockBand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rockBand);
        }

        // GET: RockBands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RockBand rockBand = db.RockBands.Find(id);
            if (rockBand == null)
            {
                return HttpNotFound();
            }
            return View(rockBand);
        }

        // POST: RockBands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RockBand rockBand = db.RockBands.Find(id);
            db.RockBands.Remove(rockBand);
            db.SaveChanges();
            return RedirectToAction("Index");
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
