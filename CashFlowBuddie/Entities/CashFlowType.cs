using CashFlowBuddie.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace CashFlowBuddie.Entities
{
    public class CashFlowType : IEntity
    {
        [DataType(DataType.Text)]
        [StringLength(128)]
        public string TypeName { get; private set; }

        [DataType(DataType.Text)]
        [StringLength(300)]
        public string Description { get; private set; }

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