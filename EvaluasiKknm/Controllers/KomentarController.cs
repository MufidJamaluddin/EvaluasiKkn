using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EvaluasiKknm.Models;

namespace EvaluasiKknm
{
    public class KomentarController : Controller
    {
        private KknmDbContext db = new KknmDbContext();

        // GET: Komentar
        public async Task<ActionResult> Index()
        {
            var komentars = db.Komentars.Include(k => k.Penilaian);
            return View(await komentars.ToListAsync());
        }

        // GET: Komentar/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentar komentar = await db.Komentars.FindAsync(id);
            if (komentar == null)
            {
                return HttpNotFound();
            }
            return View(komentar);
        }

        // GET: Komentar/Create
        public ActionResult Create()
        {
            ViewBag.IdPenilaian = new SelectList(db.Penilaians, "IdPenilaian", "Username");
            return View();
        }

        // POST: Komentar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPenilaian,IdKomentar,DescKomentar")] Komentar komentar)
        {
            if (ModelState.IsValid)
            {
                db.Komentars.Add(komentar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdPenilaian = new SelectList(db.Penilaians, "IdPenilaian", "Username", komentar.IdPenilaian);
            return View(komentar);
        }

        // GET: Komentar/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentar komentar = await db.Komentars.FindAsync(id);
            if (komentar == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPenilaian = new SelectList(db.Penilaians, "IdPenilaian", "Username", komentar.IdPenilaian);
            return View(komentar);
        }

        // POST: Komentar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPenilaian,IdKomentar,DescKomentar")] Komentar komentar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(komentar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdPenilaian = new SelectList(db.Penilaians, "IdPenilaian", "Username", komentar.IdPenilaian);
            return View(komentar);
        }

        // GET: Komentar/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentar komentar = await db.Komentars.FindAsync(id);
            if (komentar == null)
            {
                return HttpNotFound();
            }
            return View(komentar);
        }

        // POST: Komentar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Komentar komentar = await db.Komentars.FindAsync(id);
            db.Komentars.Remove(komentar);
            await db.SaveChangesAsync();
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
