﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CashFlowBuddie.Models;
using CashFlowBuddie.Entities;

namespace CashFlowBuddie.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<CashFlow>()
                .HasOne(cf => cf.CashFlowSouce)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CashFlow>()
                .HasOne(cf => cf.CashFlowType)
                .WithOne().OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<CashFlow> CashFlows { get; set; }

        public DbSet<CashFlowSource> CashFlowSources { get; set; }

        public DbSet<CashFlowType> CashFlowTypes { get; set; }
    }
}
