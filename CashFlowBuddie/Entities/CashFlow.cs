using System;
using System.ComponentModel.DataAnnotations;
using CashFlowBuddie.Abstractions;
using CashFlowBuddie.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlowBuddie.Entities
{
    public class CashFlow : IEntity
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
        public decimal Amount { get; set; }

        [Key]
        [StringLength(200)]
        public virtual string Id { get; private set; }

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