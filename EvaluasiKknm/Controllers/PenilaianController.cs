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
    public class PenilaianController : Controller
    {
        private KknmDbContext db = new KknmDbContext();

        // GET: Penilaian
        public async Task<ActionResult> Index()
        {
            var penilaians = db.Penilaians.Include(p => p.Akun).Include(p => p.Indikator).Include(p => p.Program);
            return View(await penilaians.ToListAsync());
        }

        // GET: Penilaian/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penilaian penilaian = await db.Penilaians.FindAsync(id);
            if (penilaian == null)
            {
                return HttpNotFound();
            }
            return View(penilaian);
        }

        // GET: Penilaian/Create
        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email");
            ViewBag.KodeDesa = new SelectList(db.Indikators, "KodeDesa", "Username");
            ViewBag.IdKel = new SelectList(db.Programs, "IdKel", "NamaProgram");
            return View();
        }

        // POST: Penilaian/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPenilaian,Username,KodeDesa,IdIndikator,IdKel,Id,Alasan,Skor")] Penilaian penilaian)
        {
            if (ModelState.IsValid)
            {
                db.Penilaians.Add(penilaian);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email", penilaian.Username);
            ViewBag.KodeDesa = new SelectList(db.Indikators, "KodeDesa", "Username", penilaian.KodeDesa);
            ViewBag.IdKel = new SelectList(db.Programs, "IdKel", "NamaProgram", penilaian.IdKel);
            return View(penilaian);
        }

        // GET: Penilaian/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penilaian penilaian = await db.Penilaians.FindAsync(id);
            if (penilaian == null)
            {
                return HttpNotFound();
            }
            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email", penilaian.Username);
            ViewBag.KodeDesa = new SelectList(db.Indikators, "KodeDesa", "Username", penilaian.KodeDesa);
            ViewBag.IdKel = new SelectList(db.Programs, "IdKel", "NamaProgram", penilaian.IdKel);
            return View(penilaian);
        }

        // POST: Penilaian/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPenilaian,Username,KodeDesa,IdIndikator,IdKel,Id,Alasan,Skor")] Penilaian penilaian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(penilaian).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email", penilaian.Username);
            ViewBag.KodeDesa = new SelectList(db.Indikators, "KodeDesa", "Username", penilaian.KodeDesa);
            ViewBag.IdKel = new SelectList(db.Programs, "IdKel", "NamaProgram", penilaian.IdKel);
            return View(penilaian);
        }

        // GET: Penilaian/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penilaian penilaian = await db.Penilaians.FindAsync(id);
            if (penilaian == null)
            {
                return HttpNotFound();
            }
            return View(penilaian);
        }

        // POST: Penilaian/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Penilaian penilaian = await db.Penilaians.FindAsync(id);
            db.Penilaians.Remove(penilaian);
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
