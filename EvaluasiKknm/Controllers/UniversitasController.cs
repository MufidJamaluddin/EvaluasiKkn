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
    public class UniversitasController : Controller
    {
        private KknmDbContext db = new KknmDbContext();

        // GET: Universitas
        public ActionResult Index()
        {
            return View(db.Universitas.ToList());
        }

        // GET: Universitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universita universita = db.Universitas.Find(id);
            if (universita == null)
            {
                return HttpNotFound();
            }
            return View(universita);
        }

        // GET: Universitas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Universitas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUniv,NamaUniv")] Universita universita)
        {
            if (ModelState.IsValid)
            {
                db.Universitas.Add(universita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(universita);
        }

        // GET: Universitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universita universita = db.Universitas.Find(id);
            if (universita == null)
            {
                return HttpNotFound();
            }
            return View(universita);
        }

        // POST: Universitas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUniv,NamaUniv")] Universita universita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(universita);
        }

        // GET: Universitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universita universita = db.Universitas.Find(id);
            if (universita == null)
            {
                return HttpNotFound();
            }
            return View(universita);
        }

        // POST: Universitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Universita universita = db.Universitas.Find(id);
            db.Universitas.Remove(universita);
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
