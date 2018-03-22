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
    public class DesaController : Controller
    {
        private KknmDbContext db = new KknmDbContext();

        // GET: Desa
        public async Task<ActionResult> Index()
        {
            var desas = db.Desas.Include(d => d.Kecamatan);
            return View(await desas.ToListAsync());
        }

        // GET: Desa/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desa desa = await db.Desas.FindAsync(id);
            if (desa == null)
            {
                return HttpNotFound();
            }
            return View(desa);
        }

        public async Task<ActionResult> Indikator()
        {
            int IdIndikator = -1;

            Int32.TryParse(Request.QueryString["IdIndikator"], out IdIndikator);

            if (IdIndikator == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Indikator indikator = await db.Indikators.Where(x => x.IdIndikator == IdIndikator).FirstOrDefaultAsync();

            List<IndikatorV> penilaian = await db.Penilaians.Where(x => x.IdIndikator == IdIndikator).Select(x => new IndikatorV { NamaProgram = x.Program.NamaProgram, NamaKel = x.Program.KelompokKkn.NamaKel, Skor = x.Skor, Alasan = x.Alasan, IdPenilaian = x.IdPenilaian }).ToListAsync();

            ViewBag.indikator = indikator;
            ViewBag.penilaian = penilaian;

            return View();
        }

        // GET:
        public async Task<ActionResult> Profil(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Desa desa = await db.Desas.FindAsync(id);
            List<Indikator> indikators = await db.Indikators.Where(x => x.KodeDesa == id).ToListAsync();

            if (desa == null)
            {
                return HttpNotFound();
            }

            ViewBag.desa = desa;
            ViewBag.indikators = indikators;

            return View();
        }

        // GET: Desa/Create
        public ActionResult Create()
        {
            ViewBag.KodeKec = new SelectList(db.Kecamatans, "KodeKec", "KodeKab");
            return View();
        }

        // POST: Desa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "KodeDesa,KodeKec,NamaDesa,KearifanLokal")] Desa desa)
        {
            if (ModelState.IsValid)
            {
                db.Desas.Add(desa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.KodeKec = new SelectList(db.Kecamatans, "KodeKec", "KodeKab", desa.KodeKec);
            return View(desa);
        }

        // GET: Desa/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desa desa = await db.Desas.FindAsync(id);
            if (desa == null)
            {
                return HttpNotFound();
            }
            ViewBag.KodeKec = new SelectList(db.Kecamatans, "KodeKec", "KodeKab", desa.KodeKec);
            return View(desa);
        }

        // POST: Desa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "KodeDesa,KodeKec,NamaDesa,KearifanLokal")] Desa desa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.KodeKec = new SelectList(db.Kecamatans, "KodeKec", "KodeKab", desa.KodeKec);
            return View(desa);
        }

        // GET: Desa/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desa desa = await db.Desas.FindAsync(id);
            if (desa == null)
            {
                return HttpNotFound();
            }
            return View(desa);
        }

        // POST: Desa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Desa desa = await db.Desas.FindAsync(id);
            db.Desas.Remove(desa);
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
