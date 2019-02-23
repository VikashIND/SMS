using CrystalDecisions.CrystalReports.Engine;
using MoreLinq;
using SMS.Models;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using helper;
using System.Collections;
using SMS.Alerts;

namespace SMS.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            
            if (Session["LoginID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(EmployeeMaster emp)
        {


            using (SMSDbContext db = new SMSDbContext())
            {

                var result = db.Employees.SingleOrDefault(x => x.LoginID == emp.LoginID && x.Password == emp.Password);
                if (result != null)
                {
                    Session["LoginID"] = result.LoginID;
                    Session["UserName"] = result.Name;
                    return RedirectToAction("Welcome");
                }
            }

            return View();
        }
        public ActionResult ExportDailyTask()
        {
            SMSDbContext db = new SMSDbContext();
            DataTable dt = db.DailyTasks.ToDataTable();

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

           
           
            // ds.WriteXmlSchema(@"e:\a\report1.xml");

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport1.rpt"));

            rd.SetDataSource(ds);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf");


        }
        public ActionResult Welcome()
        {
            if (Session["LoginID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}