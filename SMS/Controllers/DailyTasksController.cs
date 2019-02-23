using SMS.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace SMS.Controllers
{
    public class DailyTasksController : Controller
    {
        private readonly SMSDbContext _db = new SMSDbContext();

        public DailyTasksController()
        {

        }
        public DailyTasksController(SMSDbContext db)
        {
            this._db = db;
        }
        // GET: DailyTasks
        public async Task<ActionResult> Index()
        {
            var data = from dt in _db.DailyTasks
                       join sm in _db.StatusMasters on dt.StatusID equals sm.ID
                       join cm in _db.CategoryMasters on dt.CategoryID equals cm.ID

                       select new { dt.DeliveryDate, sm, cm };


            //return View(await data.ToListAsync());
            return View(await _db.DailyTasks.ToListAsync());



        }

        // GET: DailyTasks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyTask dailyTask = await _db.DailyTasks.FindAsync(id);
            if (dailyTask == null)
            {
                return HttpNotFound();
            }
            return View(dailyTask);
        }

        // GET: DailyTasks/Create
        public ActionResult Create()
        {
            ViewBag.ClientList = UtilFunctions.GetClients();
            ViewBag.CategoryList = UtilFunctions.GetCategories();
            ViewBag.StatusList = UtilFunctions.GetStatus();

            return View();
        }
        public ActionResult GetCientListByName(string name)
        {
            var data = _db.ClientMasters.Where(x => x.ClientName.Contains(name)).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetEmployeeByName(string search)
        {
            var result = _db.Employees.Where(x => x.Name.Contains(search)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // POST: DailyTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,EmployeeID,SupportTeam,ClientID,ClientName,CategoryID,Description,Notes,Date,AssignedDate,DeliveryDate,Status")] DailyTask dailyTask)
        {
            if (ModelState.IsValid)
            {
                _db.DailyTasks.Add(dailyTask);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dailyTask);
        }

        // GET: DailyTasks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyTask dailyTask = await _db.DailyTasks.FindAsync(id);
            if (dailyTask == null)
            {
                return HttpNotFound();
            }
            return View(dailyTask);
        }

        // POST: DailyTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,EmployeeID,SupportTeam,ClientID,ClientName,CategoryID,Description,Notes,Date,AssignedDate,DeliveryDate,Status")] DailyTask dailyTask)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(dailyTask).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dailyTask);
        }

        // GET: DailyTasks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyTask dailyTask = await _db.DailyTasks.FindAsync(id);
            if (dailyTask == null)
            {
                return HttpNotFound();
            }
            return View(dailyTask);
        }

        // POST: DailyTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DailyTask dailyTask = await _db.DailyTasks.FindAsync(id);
            _db.DailyTasks.Remove(dailyTask);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
