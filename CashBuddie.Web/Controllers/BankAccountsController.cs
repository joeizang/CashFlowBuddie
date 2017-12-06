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
using PagedList;
using CashBuddie.Web.Infrastructure.Extensions;
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
            var model = new BankAccountInputModel.BankAccountResultModel
            {
                CurrentSort = message.SortOrder,
                NameSortParm = String.IsNullOrEmpty(message.SortOrder) ? "name_desc" : "",
                DateSortParm = message.SortOrder == "Date" ? "date_desc" : "Date",
            };

            if (string.IsNullOrWhiteSpace(message.SearchString))
            {
                message.Page = 1;
            }
            else
            {
                message.SearchString = message.CurrentFilter;
            }

            model.CurrentFilter = message.SearchString;
            model.SearchString = message.SearchString;

            var accounts = from a in _db.Accounts
                           select a;
            var accounts1 = _db.Accounts.AsQueryable();
            if (!String.IsNullOrEmpty(message.SearchString))
            {
                accounts = accounts.Include(a => a.AccountHolder).Include(a => a.CashFlows)
                                    .AsNoTracking().Where(a => a.AccountName.Contains(message.SearchString) ||
                                                   a.AccountHolder.FirstName.Contains(message.SearchString));
            }

            
            switch (message.SortOrder)
            {
                case "name_desc":
                    accounts = accounts.OrderByDescending(s => s.AccountName);
                    break;
                case "typename_desc":
                    accounts = accounts.OrderByDescending(s => s.AccountName);
                    break;
                case "typename":
                    accounts = accounts.OrderByDescending(s => s.AccountName);
                    break;
                case "Amount_desc":
                    accounts = accounts.OrderByDescending(s => s.AccountName);
                    break;
                case "Amount":
                    accounts = accounts.OrderBy(s => s.BankBalance);
                    break;
                default: // Name ascending 
                    accounts = accounts.OrderBy(s => s.AccountName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (message.Page ?? 1);
            //model.Results = accounts.ProjectToPagedList<BankAccountVM>(pageNumber, pageSize);

            model.Results = accounts.Select(x => new BankAccountVM
            {
                InstitutionName = x.InstitutionName,
                Amount = x.BankBalance,
                BankAccountNumber = x.Id,
                Id = x.Id,
            }).ToPagedList(pageNumber, pageSize);

            //return model
            return View(model);
        }

        // GET: BankAccounts/Details/5
        public async Task<ActionResult> Details(BankAccountDetailModel.BankAccountDetailInputModel model)
        {
            if (model == null)
            {
                //rather than send an error page, I would like a modal stating the error message
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bankAccount = await _db.Accounts.AsNoTracking().Include(a => a.CashFlows)
                                       .Where(b => b.Id.Equals(model.Id))
                                       .ProjectToSingleOrDefaultAsync<BankAccountDetailModel>();
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
            var result = await _db.Accounts.AsNoTracking()
                .SingleOrDefaultAsync(b => b.AccountName.Equals(bankAccount.NameOfAccount)
                && b.InstitutionName.Equals(bankAccount.InstitutionName) && b.Id.Equals(bankAccount.AccountNumber));

            if (ModelState.IsValid && result != null)
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


            if (!ModelState.IsValid && await _db.Accounts.AsNoTracking()
                .AnyAsync(a => a.Id.Equals(bankAccount.AccountNumber)))
            {
                //more than one account exits that has the same account number
                ModelState.AddModelError("Error", "More than one account has the account number you are trying to use!");
            }
            else
            {
                bank = await _db.Accounts.Where(a => a.Id == bankAccount.Id).ProjectToSingleOrDefaultAsync<BankAccount>();

                _db.Entry(bank).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = await _db.Accounts.FindAsync(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            BankAccount bankAccount = await _db.Accounts.FindAsync(id);
            _db.Accounts.Remove(bankAccount);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
