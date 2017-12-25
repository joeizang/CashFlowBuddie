using CashBuddie.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashBuddie.Web.Controllers
{
    public class CashFlowController : Controller
    {
        private readonly CashBuddieContext _db;

        public CashFlowController(CashBuddieContext db)
        {
            _db = db;
        }
        // GET: CashFlow
        public ActionResult Index()
        {
            return View();
        }

        // GET: CashFlow/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CashFlow/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CashFlow/Create
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

        // GET: CashFlow/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CashFlow/Edit/5
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

        // GET: CashFlow/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CashFlow/Delete/5
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
