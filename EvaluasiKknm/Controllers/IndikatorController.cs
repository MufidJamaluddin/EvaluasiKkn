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
    public class IndikatorController : Controller
    {
        private KknmDbContext db = new KknmDbContext();

        // GET: Indikator
        public async Task<ActionResult> Index()
        {
            var indikators = db.Indikators.Include(i => i.Akun).Include(i => i.Desa);
            return View(await indikators.ToListAsync());
        }

        // GET: Indikator/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Indikator indikator = await db.Indikators.FindAsync(id);

            if (indikator == null)
            {
                return HttpNotFound();
            }
            return View(indikator);
        }

        // GET: Indikator/Details/5
        public async Task<ActionResult> Desa(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Indikator indikator = await db.Indikators.FindAsync(id);

            if (indikator == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        // GET: Indikator/Create
        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email");
            ViewBag.KodeDesa = new SelectList(db.Desas, "KodeDesa", "KodeKec");
            return View();
        }

        // POST: Indikator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "KodeDesa,IdIndikator,Username,Judul,Deskripsi,Konfirmasi")] Indikator indikator)
        {
            if (ModelState.IsValid)
            {
                db.Indikators.Add(indikator);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email", indikator.Username);
            ViewBag.KodeDesa = new SelectList(db.Desas, "KodeDesa", "KodeKec", indikator.KodeDesa);
            return View(indikator);
        }

        // GET: Indikator/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indikator indikator = await db.Indikators.FindAsync(id);
            if (indikator == null)
            {
                return HttpNotFound();
            }
            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email", indikator.Username);
            ViewBag.KodeDesa = new SelectList(db.Desas, "KodeDesa", "KodeKec", indikator.KodeDesa);
            return View(indikator);
        }

        // POST: Indikator/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "KodeDesa,IdIndikator,Username,Judul,Deskripsi,Konfirmasi")] Indikator indikator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indikator).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email", indikator.Username);
            ViewBag.KodeDesa = new SelectList(db.Desas, "KodeDesa", "KodeKec", indikator.KodeDesa);
            return View(indikator);
        }

        // GET: Indikator/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indikator indikator = await db.Indikators.FindAsync(id);
            if (indikator == null)
            {
                return HttpNotFound();
            }
            return View(indikator);
        }

        // POST: Indikator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Indikator indikator = await db.Indikators.FindAsync(id);
            db.Indikators.Remove(indikator);
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
