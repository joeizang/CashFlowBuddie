using CashFlowBuddie.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlowBuddie.Data
{
    public class CashFlowBuddieDb : DbContext
    {
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

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<CashFlow> CashFlows { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CashFlowSource> CashFlowSources { get; set; }

        public DbSet<CashFlowType> CashFlowTypes { get; set; }
    }
}
