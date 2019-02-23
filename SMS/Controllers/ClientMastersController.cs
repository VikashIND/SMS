using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models;
namespace SMS.Controllers
{
    public class ClientMastersController : Controller
    {
        SMS.Models.SMSDbContext _context = new Models.SMSDbContext();
      //public  ClientMastersController( SMSDbContext context)
      //  {
      //      _context = context;
      //  }
        // GET: ClientMasters
        public ActionResult Index()
        {
            try
            {
                int a = 4;
                int b = 0;
                int c = a / b;
                
                return View(_context.ClientMasters.ToList());
            }
            catch(Exception ex)
            {
                SMS.Helper.ExceptionLog.Save(ex);
                return View();
            }
        }

        // GET: ClientMasters/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientMasters/Create
        public ActionResult Create()
        {
            var cityList = _context.CityMasters.ToList();
            var stateList = _context.StateMasters.ToList();
            var countryList = _context.CountryMasters.ToList();
            ViewBag.CityList = cityList;
            ViewBag.StateList = stateList;
            ViewBag.CountryList = countryList;
            return View();
        }

        // POST: ClientMasters/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientMasters/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientMasters/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientMasters/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientMasters/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
