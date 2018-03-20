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

namespace EvaluasiKknm.Controllers
{
    public class KelompokController : Controller
    {
        private EvaluasiKknmDbContext db = new EvaluasiKknmDbContext();

        // GET: Kelompok
        public async Task<ActionResult> Index()
        {
            var kelompokKkns = db.KelompokKkns.Include(k => k.Desa).Include(k => k.Universita);
            return View(await kelompokKkns.ToListAsync());
        }

        // GET: Kelompok/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KelompokKkn kelompokKkn = await db.KelompokKkns.FindAsync(id);
            if (kelompokKkn == null)
            {
                return HttpNotFound();
            }
            return View(kelompokKkn);
        }

        // GET: Kelompok/Create
        public ActionResult Create()
        {
            ViewBag.KodeDesa = new SelectList(db.Desas, "KodeDesa", "KodeKec");
            ViewBag.IdUniv = new SelectList(db.Universitas, "IdUniv", "NamaUniv");
            return View();
        }

        // POST: Kelompok/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdKel,KodeDesa,IdUniv,NamaKel,TanggalMulai,TanggalAkhir,NIMKetua")] KelompokKkn kelompokKkn)
        {
            if (ModelState.IsValid)
            {
                db.KelompokKkns.Add(kelompokKkn);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.KodeDesa = new SelectList(db.Desas, "KodeDesa", "KodeKec", kelompokKkn.KodeDesa);
            ViewBag.IdUniv = new SelectList(db.Universitas, "IdUniv", "NamaUniv", kelompokKkn.IdUniv);
            return View(kelompokKkn);
        }

        // GET: Kelompok/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KelompokKkn kelompokKkn = await db.KelompokKkns.FindAsync(id);
            if (kelompokKkn == null)
            {
                return HttpNotFound();
            }
            ViewBag.KodeDesa = new SelectList(db.Desas, "KodeDesa", "KodeKec", kelompokKkn.KodeDesa);
            ViewBag.IdUniv = new SelectList(db.Universitas, "IdUniv", "NamaUniv", kelompokKkn.IdUniv);
            return View(kelompokKkn);
        }

        // POST: Kelompok/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdKel,KodeDesa,IdUniv,NamaKel,TanggalMulai,TanggalAkhir,NIMKetua")] KelompokKkn kelompokKkn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kelompokKkn).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.KodeDesa = new SelectList(db.Desas, "KodeDesa", "KodeKec", kelompokKkn.KodeDesa);
            ViewBag.IdUniv = new SelectList(db.Universitas, "IdUniv", "NamaUniv", kelompokKkn.IdUniv);
            return View(kelompokKkn);
        }

        // GET: Kelompok/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KelompokKkn kelompokKkn = await db.KelompokKkns.FindAsync(id);
            if (kelompokKkn == null)
            {
                return HttpNotFound();
            }
            return View(kelompokKkn);
        }

        // POST: Kelompok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            KelompokKkn kelompokKkn = await db.KelompokKkns.FindAsync(id);
            db.KelompokKkns.Remove(kelompokKkn);
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
