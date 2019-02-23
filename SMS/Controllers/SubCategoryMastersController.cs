using SMS.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class SubCategoryMastersController : Controller
    {
        private SMSDbContext db = new SMSDbContext();

        // GET: SubCategoryMasters
        public async Task<ActionResult> Index()
        {
            return View(await db.SubCategoryMasters.ToListAsync());
        }
        public ActionResult GetCategoryByID(string CID)
        {
            return Json(db.SubCategoryMasters.Where(x => x.CategoryID == Int32.Parse(CID)).ToList(), JsonRequestBehavior.AllowGet);
        }
        // GET: SubCategoryMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryMaster subCategoryMaster = await db.SubCategoryMasters.FindAsync(id);
            if (subCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryMaster);
        }

        // GET: SubCategoryMasters/Create
        public ActionResult Create()
        {
            ViewBag.CategoryList = db.CategoryMasters.ToList();
            return View();
        }

        // POST: SubCategoryMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,CategoryID")] SubCategoryMaster subCategoryMaster)
        {
            if (ModelState.IsValid)
            {

                db.SubCategoryMasters.Add(subCategoryMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(subCategoryMaster);
        }

        // GET: SubCategoryMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.CategoryList = db.CategoryMasters.ToList();
            SubCategoryMaster subCategoryMaster = await db.SubCategoryMasters.FindAsync(id);
            if (subCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryMaster);
        }

        // POST: SubCategoryMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,CategoryID")] SubCategoryMaster subCategoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategoryMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(subCategoryMaster);
        }

        // GET: SubCategoryMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryMaster subCategoryMaster = await db.SubCategoryMasters.FindAsync(id);
            if (subCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryMaster);
        }

        // POST: SubCategoryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SubCategoryMaster subCategoryMaster = await db.SubCategoryMasters.FindAsync(id);
            db.SubCategoryMasters.Remove(subCategoryMaster);
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
