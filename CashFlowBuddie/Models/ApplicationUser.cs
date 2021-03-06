﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using CashFlowBuddie.Entities;
using CashFlowBuddie.Abstractions;

namespace CashFlowBuddie.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser, IEntity
    {

        public ApplicationUser()
        {
            CashFlows = new List<CashFlow>();
            Accounts = new List<BankAccount>();
        }


        [Required(AllowEmptyStrings = false, ErrorMessage = "You must provide a first name to continue")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string FirstName { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must provide a last name to continue")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string LastName { get; private set; }

        [DataType(DataType.Text)]
        [StringLength(30)]
        public string OtherNames { get; private set; }

        [StringLength(150)]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must provide a password to continue")]
        public string Password { get; private set; }

        [StringLength(11)]
        public string MobileNumber { get; private set; }

        public ICollection<CashFlow> CashFlows { get; private set; }

        public ICollection<BankAccount> Accounts { get; private set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public virtual DateTimeOffset CreatedAt { get; private set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public virtual DateTimeOffset UpdatedAt { get; private set; }

        [StringLength(70)]
        public virtual string CreatedBy { get; private set; }

        [StringLength(70)]
        public virtual string UpdatedBy { get; private set; }
    }
}
