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
    public class PembinaController : Controller
    {
        private KknmDbContext db = new KknmDbContext();

        // GET: Pembina
        public ActionResult Index()
        {
            var dosenPembimbings = db.DosenPembimbings.Include(d => d.Akun).Include(d => d.KelompokKkn);
            return View(dosenPembimbings.ToList());
        }

        // GET: Pembina/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DosenPembimbing dosenPembimbing = db.DosenPembimbings.Find(id);
            if (dosenPembimbing == null)
            {
                return HttpNotFound();
            }
            return View(dosenPembimbing);
        }

        // GET: Pembina/Create
        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email");
            ViewBag.IdKel = new SelectList(db.KelompokKkns, "IdKel", "KodeDesa");
            return View();
        }

        // POST: Pembina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,NIDN,IdKel,Nama")] DosenPembimbing dosenPembimbing)
        {
            if (ModelState.IsValid)
            {
                db.DosenPembimbings.Add(dosenPembimbing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email", dosenPembimbing.Username);
            ViewBag.IdKel = new SelectList(db.KelompokKkns, "IdKel", "KodeDesa", dosenPembimbing.IdKel);
            return View(dosenPembimbing);
        }

        // GET: Pembina/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DosenPembimbing dosenPembimbing = db.DosenPembimbings.Find(id);
            if (dosenPembimbing == null)
            {
                return HttpNotFound();
            }
            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email", dosenPembimbing.Username);
            ViewBag.IdKel = new SelectList(db.KelompokKkns, "IdKel", "KodeDesa", dosenPembimbing.IdKel);
            return View(dosenPembimbing);
        }

        // POST: Pembina/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,NIDN,IdKel,Nama")] DosenPembimbing dosenPembimbing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dosenPembimbing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email", dosenPembimbing.Username);
            ViewBag.IdKel = new SelectList(db.KelompokKkns, "IdKel", "KodeDesa", dosenPembimbing.IdKel);
            return View(dosenPembimbing);
        }

        // GET: Pembina/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DosenPembimbing dosenPembimbing = db.DosenPembimbings.Find(id);
            if (dosenPembimbing == null)
            {
                return HttpNotFound();
            }
            return View(dosenPembimbing);
        }

        // POST: Pembina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DosenPembimbing dosenPembimbing = db.DosenPembimbings.Find(id);
            db.DosenPembimbings.Remove(dosenPembimbing);
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
