using System;
using System.Collections.Generic;
using EFDbFactory = System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using CashFlowBuddie.Domain.Data;

namespace CashFlowBuddie.Domain.Data
{
    public class CashFlowBuddieContext : EFDbFactory.IDbContextFactory<CashFlowBuddieDb>
    {
        public string GetConnectionTxt => "Server=(localdb)\\mssqllocaldb;Database=CashFlowBuddieDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        public CashFlowBuddieDb Create()
        {
            return new CashFlowBuddieDb(GetConnectionTxt);
        }
    }
}
