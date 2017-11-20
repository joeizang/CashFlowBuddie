using CashFlowBuddie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlowBuddie.Domain.Data
{
    public class CashFlowBuddieDb : DbContext
    {
        public CashFlowBuddieDb(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CashFlow>()
                .HasRequired(cf => cf.CashFlowType)
                .WithOptional()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CashFlow>()
                .HasRequired(cf => cf.CashFlowSouce)
                .WithOptional()
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        
    }
}
