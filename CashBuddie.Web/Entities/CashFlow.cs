using System;
using System.ComponentModel.DataAnnotations;
using CashFlowBuddie.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using CashBuddie.Web.Models;

namespace CashFlowBuddie.Web.Entities
{
    public class CashFlow : EntityBase
    {
        public CashFlow()
        {

        }

        [DataType(DataType.Text)]
        [StringLength(128)]
        public string AccountId { get; private set; }

        public BankAccount BankAccount { get; private set; }

        [ForeignKey("CashFlowSourceId")]
        public CashFlowSource CashFlowSouce { get; private set; }

        [DataType(DataType.Text)]
        [StringLength(128)]
        public string CashFlowSourceId { get; private set; }

        [ForeignKey("CashFlowTypeId")]
        public CashFlowType CashFlowType { get; private set; }

        [DataType(DataType.Text)]
        [StringLength(128)]
        public string CashFlowTypeId { get; private set; }

        public string UserId { get; private set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; private set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d2}")]
        public decimal Amount { get; private set; }
    }
}