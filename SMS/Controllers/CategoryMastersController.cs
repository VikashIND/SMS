using SMS.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class CategoryMastersController : Controller
    {
        private SMSDbContext db = new SMSDbContext();

        // GET: CategoryMasters
        public async Task<ActionResult> Index()
        {
            return View(await db.CategoryMasters.ToListAsync());
        }

        // GET: CategoryMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = await db.CategoryMasters.FindAsync(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // GET: CategoryMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name")] CategoryMaster categoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.CategoryMasters.Add(categoryMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(categoryMaster);
        }

        // GET: CategoryMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = await db.CategoryMasters.FindAsync(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // POST: CategoryMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name")] CategoryMaster categoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoryMaster);
        }

        // GET: CategoryMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = await db.CategoryMasters.FindAsync(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // POST: CategoryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CategoryMaster categoryMaster = await db.CategoryMasters.FindAsync(id);
            db.CategoryMasters.Remove(categoryMaster);
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
