using SMS.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class StateMastersController : Controller
    {
        private SMSDbContext db = new SMSDbContext();

        // GET: StateMasters
        public async Task<ActionResult> Index()
        {
            ViewBag.CountryList = db.CountryMasters.ToList();
            return View(await db.StateMasters.ToListAsync());
        }

        // GET: StateMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMaster stateMaster = await db.StateMasters.FindAsync(id);
            if (stateMaster == null)
            {
                return HttpNotFound();
            }
            return View(stateMaster);
        }

        // GET: StateMasters/Create
        public ActionResult Create()
        {
            ViewBag.CountryList = db.CountryMasters.ToList();
            return View();
        }

        // POST: StateMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,CountryID")] StateMaster stateMaster)
        {
            if (ModelState.IsValid)
            {
                db.StateMasters.Add(stateMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(stateMaster);
        }

        // GET: StateMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMaster stateMaster = await db.StateMasters.FindAsync(id);
            if (stateMaster == null)
            {
                return HttpNotFound();
            }
            return View(stateMaster);
        }

        // POST: StateMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,CountryID")] StateMaster stateMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stateMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stateMaster);
        }

        // GET: StateMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMaster stateMaster = await db.StateMasters.FindAsync(id);
            if (stateMaster == null)
            {
                return HttpNotFound();
            }
            return View(stateMaster);
        }

        // POST: StateMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StateMaster stateMaster = await db.StateMasters.FindAsync(id);
            db.StateMasters.Remove(stateMaster);
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
