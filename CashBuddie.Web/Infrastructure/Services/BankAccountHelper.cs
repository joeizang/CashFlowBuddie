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
    public static class BankAccountHelper
    {

        

        public static BankAccountInputModel.BankAccountResultModel PrepareResultModel(BankAccountInputModel message)
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

            return model;
        }

        /// <summary>
        /// Filter BankAccounts based on inputs found in type contained in message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IQueryable<BankAccount> FilterOnContext( 
            BankAccountInputModel.BankAccountResultModel message,CashBuddieContext db)
        {
            var accounts = from a in db.Accounts
                           select a;

            if (!String.IsNullOrEmpty(message.SearchString))
            {
                accounts = accounts.Include(a => a.AccountHolder).Include(a => a.CashFlows)
                                   .AsNoTracking().Where(a => a.AccountName.Contains(message.SearchString) ||
                                   a.AccountHolder.FirstName.Contains(message.SearchString));
            }

            return accounts;
        }

        public static IQueryable<BankAccount> SortBankAccountSet(IQueryable<BankAccount> accounts, 
            BankAccountInputModel.BankAccountResultModel message)
        {
            switch (message.CurrentSort)
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

            return accounts;
        }

        public static BankAccountInputModel.BankAccountResultModel ToResultModel(
            IQueryable<BankAccount> accounts, BankAccountInputModel message,
            BankAccountInputModel.BankAccountResultModel model)
        {
            int pageSize = 3;
            int pageNumber = (message.Page ?? 1);


            model.Results = accounts.Select(x => new BankAccountVM
            {
                InstitutionName = x.InstitutionName,
                Amount = x.BankBalance,
                BankAccountNumber = x.Id,
                Id = x.Id,
            }).ToPagedList(pageNumber, pageSize);

            return model;
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
                && b.InstitutionName.Equals(bankAccount.InstitutionName) && 
                b.Id.Equals(bankAccount.AccountNumber));

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