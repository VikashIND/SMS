using SMS.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class EmployeeMastersController : Controller
    {
        private SMSDbContext db= new SMSDbContext();
        public EmployeeMastersController()
        {
                
        }
        public EmployeeMastersController(SMSDbContext _db)
        {
            this.db = _db;
        }

        // GET: EmployeeMasters
        public async Task<ActionResult> Index()
        {
            return View(await db.Employees.ToListAsync());
        }

        // GET: EmployeeMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeMaster employeeMaster = await db.Employees.FindAsync(id);
            if (employeeMaster == null)
            {
                return HttpNotFound();
            }
            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,SupportTeam,LoginID,Password")] EmployeeMaster employeeMaster)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employeeMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeMaster employeeMaster = await db.Employees.FindAsync(id);
            if (employeeMaster == null)
            {
                return HttpNotFound();
            }
            return View(employeeMaster);
        }

        // POST: EmployeeMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,SupportTeam,LoginID,Password")] EmployeeMaster employeeMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeMaster employeeMaster = await db.Employees.FindAsync(id);
            if (employeeMaster == null)
            {
                return HttpNotFound();
            }
            return View(employeeMaster);
        }

        // POST: EmployeeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmployeeMaster employeeMaster = await db.Employees.FindAsync(id);
            db.Employees.Remove(employeeMaster);
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
