using CashBuddie.Web.Models;
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

        [DataType(DataType.Text)]
        [StringLength(50)]
        public string AccountName { get; private set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d2}")]
        public decimal BankBalance { get; private set; }


        public ICollection<CashFlow> CashFlows { get; private set; }

        public ApplicationUser AccountHolder { get; private set; }

        public string UserId { get; private set; }
    }
}
