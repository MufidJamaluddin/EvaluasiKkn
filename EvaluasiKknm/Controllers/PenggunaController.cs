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
    public class PenggunaController : Controller
    {
        private KknmDbContext db = new KknmDbContext();

        // GET: Pengguna
        public ActionResult Index()
        {
            return View(db.Akuns.ToList());
        }

        // GET: Pengguna/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Akun akun = db.Akuns.Find(id);
            if (akun == null)
            {
                return HttpNotFound();
            }
            return View(akun);
        }

        // GET: Pengguna/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pengguna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Email,Password")] Akun akun)
        {
            if (ModelState.IsValid)
            {
                db.Akuns.Add(akun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(akun);
        }

        // GET: Pengguna/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Akun akun = db.Akuns.Find(id);
            if (akun == null)
            {
                return HttpNotFound();
            }
            return View(akun);
        }

        // POST: Pengguna/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Email,Password")] Akun akun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(akun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(akun);
        }

        // GET: Pengguna/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Akun akun = db.Akuns.Find(id);
            if (akun == null)
            {
                return HttpNotFound();
            }
            return View(akun);
        }

        // POST: Pengguna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Akun akun = db.Akuns.Find(id);
            db.Akuns.Remove(akun);
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
