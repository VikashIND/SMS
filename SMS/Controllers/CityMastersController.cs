using SMS.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class CityMastersController : Controller
    {
        private SMSDbContext db = new SMSDbContext();

        // GET: CityMasters
        public async Task<ActionResult> Index()
        {
            return View(await db.CityMasters.ToListAsync());
        }

        // GET: CityMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityMaster cityMaster = await db.CityMasters.FindAsync(id);
            if (cityMaster == null)
            {
                return HttpNotFound();
            }
            return View(cityMaster);
        }

        // GET: CityMasters/Create
        public ActionResult Create()
        {
            ViewBag.StateList = db.StateMasters.ToList();
            return View();
        }

        // POST: CityMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,StateID")] CityMaster cityMaster)
        {
            if (ModelState.IsValid)
            {
                db.CityMasters.Add(cityMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cityMaster);
        }

        // GET: CityMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.StateList = db.StateMasters.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityMaster cityMaster = await db.CityMasters.FindAsync(id);
            if (cityMaster == null)
            {
                return HttpNotFound();
            }
            return View(cityMaster);
        }

        // POST: CityMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,StateID")] CityMaster cityMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cityMaster);
        }

        // GET: CityMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityMaster cityMaster = await db.CityMasters.FindAsync(id);
            if (cityMaster == null)
            {
                return HttpNotFound();
            }
            return View(cityMaster);
        }

        // POST: CityMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CityMaster cityMaster = await db.CityMasters.FindAsync(id);
            db.CityMasters.Remove(cityMaster);
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
