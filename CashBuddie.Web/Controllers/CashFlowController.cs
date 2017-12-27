using AutoMapper;
using CashBuddie.Web.Abstractions;
using CashBuddie.Web.Models;
using CashBuddie.Web.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CashBuddie.Web.Controllers
{
    public class CashFlowController : Controller
    {
        private readonly CashBuddieContext _db;

        private readonly ICashBuddieHelper _helper;

        public CashFlowController(CashBuddieContext db, ICashBuddieHelper helper)
        {
            _db = db;
            _helper = helper;
        }
        // GET: CashFlow
        public ActionResult Index(CashFlowInputModel model)
        {
            var result = _helper.PrepareResultModel(model)
                                .FilterOnContext(_db)
                                .SortBankAccountSet()
                                .ToResultModel(5);
            return View(result);
        }

        // GET: CashFlow/Details/5
        public async Task<ActionResult> Details(CashFlowDetailModel model)
        {
            var result = await _db.CashFlows.AsNoTracking().Where(c => c.Id.Equals(model.Id))
                                      .ProjectToSingleOrDefaultAsync<CashFlowDetailModel>();
            return View(result);
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
