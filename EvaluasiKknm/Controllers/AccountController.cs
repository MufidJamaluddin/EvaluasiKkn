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
    public class AccountController : Controller
    {
        private KknmDbContext db = new KknmDbContext();

        // GET: Account
        public async Task<ActionResult> Index()
        {
            return View(await db.Akuns.ToListAsync());
        }

        // GET: Account/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Akun akun = await db.Akuns.FindAsync(id);
            if (akun == null)
            {
                return HttpNotFound();
            }
            return View(akun);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Username,Email,Password")] Akun akun)
        {
            if (ModelState.IsValid)
            {
                db.Akuns.Add(akun);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(akun);
        }

        // GET: Account/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Akun akun = await db.Akuns.FindAsync(id);
            if (akun == null)
            {
                return HttpNotFound();
            }
            return View(akun);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Username,Email,Password")] Akun akun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(akun).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(akun);
        }

        // GET: Account/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Akun akun = await db.Akuns.FindAsync(id);
            if (akun == null)
            {
                return HttpNotFound();
            }
            return View(akun);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Akun akun = await db.Akuns.FindAsync(id);
            db.Akuns.Remove(akun);
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
