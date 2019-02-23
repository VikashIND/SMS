using SMS.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class StatusMastersController : Controller
    {
        private SMSDbContext db = new SMSDbContext();

        // GET: StatusMasters
        public async Task<ActionResult> Index()
        {
            return View(await db.StatusMasters.ToListAsync());
        }

        // GET: StatusMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusMaster statusMaster = await db.StatusMasters.FindAsync(id);
            if (statusMaster == null)
            {
                return HttpNotFound();
            }
            return View(statusMaster);
        }

        // GET: StatusMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name")] StatusMaster statusMaster)
        {
            if (ModelState.IsValid)
            {
                db.StatusMasters.Add(statusMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(statusMaster);
        }

        // GET: StatusMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusMaster statusMaster = await db.StatusMasters.FindAsync(id);
            if (statusMaster == null)
            {
                return HttpNotFound();
            }
            return View(statusMaster);
        }

        // POST: StatusMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name")] StatusMaster statusMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(statusMaster);
        }

        // GET: StatusMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusMaster statusMaster = await db.StatusMasters.FindAsync(id);
            if (statusMaster == null)
            {
                return HttpNotFound();
            }
            return View(statusMaster);
        }

        // POST: StatusMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StatusMaster statusMaster = await db.StatusMasters.FindAsync(id);
            db.StatusMasters.Remove(statusMaster);
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
