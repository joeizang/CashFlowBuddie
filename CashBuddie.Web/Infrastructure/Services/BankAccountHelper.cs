using AutoMapper;
using CashBuddie.Web.Models;
using CashBuddie.Web.Models.InputModels;
using CashFlowBuddie.Abstractions;
using CashFlowBuddie.Web.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CashBuddie.Web.Infrastructure.Services
{
    public class BankAccountHelper
    {

        private BankAccountInputModel.BankAccountResultModel ResultModel { get; set; }

        private IQueryable<BankAccount> Accounts { get; set; }


        public BankAccountHelper PrepareResultModel(BankAccountInputModel message)
        {
            var model = new BankAccountInputModel.BankAccountResultModel
            {
                CurrentSort = message.SortOrder,
                NameSortParm = String.IsNullOrEmpty(message.SortOrder) ? "name_desc" : "",
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

            ResultModel = model;

            return this;
        }

        /// <summary>
        /// Filter BankAccounts based on inputs contained in message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public BankAccountHelper FilterOnContext(CashBuddieContext db)
        {
            Accounts = from a in db.Accounts
                           select a;

            if (!String.IsNullOrEmpty(ResultModel.SearchString))
            {
                Accounts = Accounts.Include(a => a.AccountHolder).Include(a => a.CashFlows)
                                   .AsNoTracking().Where(a => a.AccountName.Contains(ResultModel.SearchString) ||
                                   a.AccountHolder.FirstName.Contains(ResultModel.SearchString));
            }

            return this;
        }

        public BankAccountHelper SortBankAccountSet()
        {
            switch (ResultModel.CurrentSort)
            {
                case "name_desc":
                    Accounts = Accounts.OrderByDescending(s => s.AccountName);
                    break;
                case "typename_desc":
                    Accounts = Accounts.OrderByDescending(s => s.AccountName);
                    break;
                case "typename":
                    Accounts = Accounts.OrderByDescending(s => s.AccountName);
                    break;
                case "Amount_desc":
                    Accounts = Accounts.OrderByDescending(s => s.AccountName);
                    break;
                case "Amount":
                    Accounts = Accounts.OrderBy(s => s.BankBalance);
                    break;
                default: // Name ascending 
                    Accounts = Accounts.OrderBy(s => s.AccountName);
                    break;
            }

            return this;
        }

        public BankAccountInputModel.BankAccountResultModel ToResultModel(BankAccountInputModel message)
        {
            int pageSize = 3;
            int pageNumber = (message.Page ?? 1);


            ResultModel.Results = Accounts.Select(x => new BankAccountVM
            {
                InstitutionName = x.InstitutionName,
                Amount = x.BankBalance,
                BankAccountNumber = x.Id,
                Id = x.Id,
            }).ToPagedList(pageNumber, pageSize);

            return ResultModel;
        }


        public static async Task<BankAccountDetailModel> FindAnAccount(BankAccountDetailModel.BankAccountDetailInputModel model,
            CashBuddieContext db)
        {
            return await db.Accounts.AsNoTracking().Include(a => a.CashFlows)
                                       .Where(b => b.Id.Equals(model.Id))
                                       .ProjectToSingleOrDefaultAsync<BankAccountDetailModel>();
        }

        public static async Task<bool> CheckForDuplicates(CashBuddieContext db, CreateBankAccountModel bankAccount)
        {
            var result = await db.Accounts.AsNoTracking()
                .SingleOrDefaultAsync(b => b.AccountName.Equals(bankAccount.NameOfAccount)
                && b.InstitutionName.Equals(bankAccount.InstitutionName));

            if (result != null)
                return true;

            return false;

        }

        //public static async Task<T> SelectAndProjectToViewModel<T,U>() where T : class where U : IEntity
        //{
        //    return T;
        //}


    }
}