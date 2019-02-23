using SMS.Models;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class ImageUploadersController : Controller
    {
        private SMSDbContext db = new SMSDbContext();

        // GET: ImageUploaders
        public async Task<ActionResult> Index()
        {
            return View(await db.ImageUploaders.ToListAsync());
        }

        // GET: ImageUploaders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageUploader imageUploader = await db.ImageUploaders.FindAsync(id);
            if (imageUploader == null)
            {
                return HttpNotFound();
            }
            return View(imageUploader);
        }

        // GET: ImageUploaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageUploaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Address,ImagePath")] ImageUploader imageUploader, HttpPostedFileBase file1)
        {
            if (file1 != null && file1.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file1.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                file1.SaveAs(path);

                if (ModelState.IsValid)
                {
                    imageUploader.ImagePath = file1.FileName;
                    db.ImageUploaders.Add(imageUploader);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return View(imageUploader);
        }

        // GET: ImageUploaders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageUploader imageUploader = await db.ImageUploaders.FindAsync(id);
            if (imageUploader == null)
            {
                return HttpNotFound();
            }
            return View(imageUploader);
        }

        // POST: ImageUploaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Address,ImagePath")] ImageUploader imageUploader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageUploader).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(imageUploader);
        }

        // GET: ImageUploaders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageUploader imageUploader = await db.ImageUploaders.FindAsync(id);
            if (imageUploader == null)
            {
                return HttpNotFound();
            }
            return View(imageUploader);
        }

        // POST: ImageUploaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ImageUploader imageUploader = await db.ImageUploaders.FindAsync(id);
            db.ImageUploaders.Remove(imageUploader);
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
