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
    public class PemdaController : Controller
    {
        private EvaluasiKknmDbContext db = new EvaluasiKknmDbContext();

        // GET: Pemda
        public async Task<ActionResult> Index()
        {
            var pemdas = db.Pemdas.Include(p => p.Akun).Include(p => p.Desa);
            return View(await pemdas.ToListAsync());
        }

        // GET: Pemda/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pemda pemda = await db.Pemdas.FindAsync(id);
            if (pemda == null)
            {
                return HttpNotFound();
            }
            return View(pemda);
        }

        // GET: Pemda/Create
        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email");
            ViewBag.KodeDesa = new SelectList(db.Desas, "KodeDesa", "KodeKec");
            return View();
        }

        // POST: Pemda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Username,NIP,KodeDesa,NamaLengkap")] Pemda pemda)
        {
            if (ModelState.IsValid)
            {
                db.Pemdas.Add(pemda);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email", pemda.Username);
            ViewBag.KodeDesa = new SelectList(db.Desas, "KodeDesa", "KodeKec", pemda.KodeDesa);
            return View(pemda);
        }

        // GET: Pemda/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pemda pemda = await db.Pemdas.FindAsync(id);
            if (pemda == null)
            {
                return HttpNotFound();
            }
            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email", pemda.Username);
            ViewBag.KodeDesa = new SelectList(db.Desas, "KodeDesa", "KodeKec", pemda.KodeDesa);
            return View(pemda);
        }

        // POST: Pemda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Username,NIP,KodeDesa,NamaLengkap")] Pemda pemda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pemda).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.Akuns, "Username", "Email", pemda.Username);
            ViewBag.KodeDesa = new SelectList(db.Desas, "KodeDesa", "KodeKec", pemda.KodeDesa);
            return View(pemda);
        }

        // GET: Pemda/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pemda pemda = await db.Pemdas.FindAsync(id);
            if (pemda == null)
            {
                return HttpNotFound();
            }
            return View(pemda);
        }

        // POST: Pemda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Pemda pemda = await db.Pemdas.FindAsync(id);
            db.Pemdas.Remove(pemda);
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
