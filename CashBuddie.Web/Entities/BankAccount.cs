using CashBuddie.Web.Models;
using CashBuddie.Web.Models.InputModels;
using CashFlowBuddie.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlowBuddie.Web.Entities
{
    public class BankAccount : EntityBase
    {

        public BankAccount()
        {
            CashFlows = new List<CashFlow>();
        }

        public BankAccount(CreateBankAccountModel account)
        {
            AccountName = account.NameOfAccount;
            BankBalance = account.AccountBalance;
            InstitutionName = account.InstitutionName;
            CreatedAt = DateTimeOffset.UtcNow;
            Id = account.AccountNumber;
            
        }

        public BankAccount(BankAccountEditModel account)
        {
            AccountName = account.NameOfAccount;
            BankBalance = account.AccountBalance;
            InstitutionName = account.InstitutionName;
            CreatedAt = DateTimeOffset.UtcNow;
            Id = account.AccountNumber;
            
        }

    [DataType(DataType.Text)]
        [StringLength(50)]
        public string AccountName { get; private set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d2}")]
        public decimal BankBalance { get; private set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string InstitutionName { get; set; }


        public ICollection<CashFlow> CashFlows { get; private set; }

        //Users need to signup before they can create bank accounts
        public ApplicationUser AccountHolder { get; private set; }

        public string UserId { get; private set; }
    }
}
