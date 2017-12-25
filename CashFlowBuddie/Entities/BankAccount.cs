using CashFlowBuddie.Abstractions;
using CashFlowBuddie.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlowBuddie.Entities
{
    public class BankAccount : IEntity
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
