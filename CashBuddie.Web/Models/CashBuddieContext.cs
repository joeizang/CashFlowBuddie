using CashFlowBuddie.Web.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CashBuddie.Web.Models
{

    public class CashBuddieContext : IdentityDbContext<ApplicationUser>
    {
        public CashBuddieContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CashBuddieContext Create()
        {
            return new CashBuddieContext();
        }

        public DbSet<CashFlow> CashFlows { get; set; }

        public DbSet<BankAccount> Accounts { get; set; }

        public DbSet<CashFlowSource> CashFlowSource { get; set; }

        public DbSet<CashFlowType> CashFlowTypes { get; set; }

    }
}