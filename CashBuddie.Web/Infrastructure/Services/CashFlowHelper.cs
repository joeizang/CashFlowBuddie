using AutoMapper;
using CashBuddie.Web.Abstractions;
using CashBuddie.Web.Models;
using CashBuddie.Web.Models.InputModels;
using CashFlowBuddie.Web.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CashBuddie.Web.Infrastructure.Services
{
    public class CashFlowHelper : ICashBuddieHelper
    {
        private CashFlowResultModel Result { get; set; }

        private IQueryable<CashFlow> CashFlows { get; set; }

        private InputModelBase Message { get; set; }

        public ICashBuddieHelper FilterOnContext(CashBuddieContext db)
        {
            CashFlows = from a in db.CashFlows
                       select a;

            if (!String.IsNullOrEmpty(Result.SearchString))
            {
                CashFlows = CashFlows
                                .Include(c => c.CashFlowType).Include(c => c.CashFlowSouce)
                                .AsNoTracking().Where(c => c.Amount.Equals(Result.SearchString) ||
                                   c.CashFlowType.TypeName.Contains(Result.SearchString) ||
                                   c.CashFlowSouce.CashFlowSourceName.Contains(Result.SearchString) ||
                                   c.CreatedAt.Equals(Result.SearchString));
            }

            return this;
        }

        public ICashBuddieHelper PrepareResultModel(InputModelBase model)
        {
            Message = model;
            var resultmodel = new CashFlowResultModel
            {
                CurrentFilter = string.IsNullOrEmpty(model.CurrentFilter) ? "something" : "",
                CurrentSort = Message.SortOrder
            };

            if(string.IsNullOrWhiteSpace(Message.SearchString))
            {
                model.Page = 1;
            }
            else
            {
                model.SearchString = Message.CurrentFilter;
            }

            resultmodel.CurrentFilter = Message.SearchString;
            resultmodel.SearchString = Message.SearchString;

            Result = resultmodel;

            return this;
        }

        public ICashBuddieHelper SortBankAccountSet()
        {
            switch (Result.CurrentSort)
            {
                case "name_desc":
                    CashFlows = CashFlows.OrderByDescending(c => c.Amount);
                    break;
                case "typename_desc":
                    CashFlows = CashFlows.OrderByDescending(c => c.BankAccount);
                    break;
                case "typename":
                    CashFlows = CashFlows.OrderByDescending(c => c.CreatedAt);
                    break;
                case "Amount_desc":
                    CashFlows = CashFlows.OrderByDescending(c => c.CashFlowSouce.CashFlowSourceName);
                    break;
                default: // Name ascending 
                    CashFlows = CashFlows.OrderBy(s => s.CashFlowType.TypeName);
                    break;
            }

            return this;
        }

        public ResultModelBase ToResultModel(int? page_size)
        {
            int pageSize = page_size.Value;
            int pageNumber = (Message.Page ?? 1);

            Result.Results = CashFlows.Select(x => new CashFlowVM
            {
                    Source = x.CashFlowSouce.CashFlowSourceName,
                    Type = x.CashFlowType.TypeName,
                    Amount = x.Amount,
                    CashActivityDate = x.CreatedAt,
                    BankAccountId = x.AccountId,
                    Id = x.Id,
            }).ToPagedList(pageNumber, pageSize);

            return Result;
        }

        public async Task CreateCashFlowItem(CreateCashFlowModel model, CashBuddieContext db)
        {
            var entity = Mapper.Map<CashFlow>(model);

            try
            {
                db.CashFlows.Add(entity);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }
        }
    }
}