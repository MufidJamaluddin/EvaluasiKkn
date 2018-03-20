using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EvaluasiKknm.Models;

namespace EvaluasiKknm.Controllers
{
    public class KecamatanController : Controller
    {
        private EvaluasiKknmDbContext db = new EvaluasiKknmDbContext();

        // GET: Kecamatan
        public ActionResult Index()
        {
            var kecamatans = db.Kecamatans.Include(k => k.Kabupaten);
            return View(kecamatans.ToList());
        }

        // GET: Kecamatan/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kecamatan kecamatan = db.Kecamatans.Find(id);
            if (kecamatan == null)
            {
                return HttpNotFound();
            }
            return View(kecamatan);
        }

        // GET: Kecamatan/Create
        public ActionResult Create()
        {
            ViewBag.KodeKab = new SelectList(db.Kabupatens, "KodeKab", "KodeProv");
            return View();
        }

        // POST: Kecamatan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KodeKec,KodeKab,NamaKec")] Kecamatan kecamatan)
        {
            if (ModelState.IsValid)
            {
                db.Kecamatans.Add(kecamatan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KodeKab = new SelectList(db.Kabupatens, "KodeKab", "KodeProv", kecamatan.KodeKab);
            return View(kecamatan);
        }

        // GET: Kecamatan/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kecamatan kecamatan = db.Kecamatans.Find(id);
            if (kecamatan == null)
            {
                return HttpNotFound();
            }
            ViewBag.KodeKab = new SelectList(db.Kabupatens, "KodeKab", "KodeProv", kecamatan.KodeKab);
            return View(kecamatan);
        }

        // POST: Kecamatan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KodeKec,KodeKab,NamaKec")] Kecamatan kecamatan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kecamatan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KodeKab = new SelectList(db.Kabupatens, "KodeKab", "KodeProv", kecamatan.KodeKab);
            return View(kecamatan);
        }

        // GET: Kecamatan/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kecamatan kecamatan = db.Kecamatans.Find(id);
            if (kecamatan == null)
            {
                return HttpNotFound();
            }
            return View(kecamatan);
        }

        // POST: Kecamatan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Kecamatan kecamatan = db.Kecamatans.Find(id);
            db.Kecamatans.Remove(kecamatan);
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
