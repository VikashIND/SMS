using SMS.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class CountryMastersController : Controller
    {
        private SMSDbContext db = new SMSDbContext();

        // GET: CountryMasters
        public async Task<ActionResult> Index()
        {
            return View(await db.CountryMasters.ToListAsync());
        }

        // GET: CountryMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryMaster countryMaster = await db.CountryMasters.FindAsync(id);
            if (countryMaster == null)
            {
                return HttpNotFound();
            }
            return View(countryMaster);
        }

        // GET: CountryMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name")] CountryMaster countryMaster)
        {
            if (ModelState.IsValid)
            {
                db.CountryMasters.Add(countryMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(countryMaster);
        }

        // GET: CountryMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryMaster countryMaster = await db.CountryMasters.FindAsync(id);
            if (countryMaster == null)
            {
                return HttpNotFound();
            }
            return View(countryMaster);
        }

        // POST: CountryMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name")] CountryMaster countryMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(countryMaster);
        }

        // GET: CountryMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryMaster countryMaster = await db.CountryMasters.FindAsync(id);
            if (countryMaster == null)
            {
                return HttpNotFound();
            }
            return View(countryMaster);
        }

        // POST: CountryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CountryMaster countryMaster = await db.CountryMasters.FindAsync(id);
            db.CountryMasters.Remove(countryMaster);
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
