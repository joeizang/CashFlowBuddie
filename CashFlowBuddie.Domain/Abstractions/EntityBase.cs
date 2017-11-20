using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlowBuddie.Data.Abstractions
{
    public class EntityBase : IEntity
    {
        [Key]
        [StringLength(128)]
        public virtual string Id { get; private set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:d}")]
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
