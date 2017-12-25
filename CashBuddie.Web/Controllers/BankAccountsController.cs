using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CashBuddie.Web.Models;
using CashFlowBuddie.Web.Entities;
using AutoMapper;
using CashBuddie.Web.Infrastructure.Services;
using CashBuddie.Web.Models.InputModels;

namespace CashBuddie.Web.Controllers
{
    public class BankAccountsController : Controller
    {
        private readonly CashBuddieContext _db;

        public BankAccountsController(CashBuddieContext db)
        {
            _db = db;
        }

        // GET: BankAccounts
        public ActionResult Index(BankAccountInputModel message)
        {
            var helper = new BankAccountHelper();

            var results = helper.PrepareResultModel(message)
                  .FilterOnContext(_db)
                  .SortBankAccountSet()
                  .ToResultModel(message);

            //return model
            return View(results);
        }

        // GET: BankAccounts/Details/5
        public async Task<ActionResult> Details(BankAccountDetailModel.BankAccountDetailInputModel model)
        {
            if (model == null)
            {
                //rather than send an error page, I would like a modal stating the error message
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bankAccount = await BankAccountHelper.FindAnAccount(model, _db);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Create
        public ActionResult Create()
        {
            //make it to return a partial so that it can be a modal window pop up.
            return View();
        }

        // POST: BankAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBankAccountModel bankAccount)
        {
            var result = await BankAccountHelper.CheckForDuplicates(_db, bankAccount);

            if (ModelState.IsValid && result)
            {
                ModelState.AddModelError("Error", "The Account You Tried To Create Already Exists!!");
            }
            else if (ModelState.IsValid)
            {
                var newBank = new BankAccount(bankAccount)
                {

                    //check to make sure that a someone is logged in and use their credentials

                    CreatedBy = HttpContext.User.Identity.IsAuthenticated ? HttpContext.User.Identity.Name : "Anonymous"
                };

                _db.Accounts.Add(newBank);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(bankAccount);
        }

        // GET: BankAccounts/Edit/5
        public async Task<ActionResult> Edit(BankAccountEditModel.BankAccountEditInputModel input)
        {
            if (string.IsNullOrEmpty(input.Id.Trim()))
            {
                //flash a message that says an Id must be supplied and then redirect to Index
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bankAccount = await _db.Accounts.AsNoTracking().Where(a => a.Id.Equals(input.Id))
                                               .ProjectToSingleOrDefaultAsync<BankAccountEditModel>();
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BankAccountEditModel bankAccount)
        {
            BankAccount bank;


            if (!ModelState.IsValid && await AccountExits(bankAccount))
            {
                //more than one account exits that has the same account number
                ModelState.AddModelError("Error", "More than one account has the account number you are trying to use!");
            }
            else
            {
                bank = await _db.Accounts.Where(a => a.Id == bankAccount.Id).SingleOrDefaultAsync();

                Mapper.Map(bankAccount, bank);

                _db.Entry(bank).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bankAccount);
        }

        private async Task<bool> AccountExits(BankAccountEditModel bankAccount)
        {
            return await _db.Accounts.AsNoTracking()
                            .AnyAsync(a => a.Id.Equals(bankAccount.AccountNumber));
        }

        // GET: BankAccounts/Delete/5
        public async Task<ActionResult> Delete(BankAccountDeleteModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Id))
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                model.Message = "Make sure you are trying to delete a valid account!";
                return View("Index", model);
            }

            var bankAccount = await _db.Accounts.
                Where(a => a.Id.Equals(model.Id))
                .ProjectToSingleOrDefaultAsync<BankAccountDeleteModel>();


            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(BankAccountDeleteModel model)
        {
            try
            {
                await DoDelete(model);
                model.Message = "Delete Successful!";
                TempData["Message"] = model;
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                model.Message = e.InnerException.Message;
                return View("Delete", model);
            }
        }

        private async Task DoDelete(BankAccountDeleteModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Id))
                {
                    _db.Entry(new BankAccount { Id = model.Id }).State = EntityState.Deleted;
                    await _db.SaveChangesAsync(); 
                }
            }
            catch (Exception e)
            {
                model.Message = e.Message;
            }
        }

    }
}
