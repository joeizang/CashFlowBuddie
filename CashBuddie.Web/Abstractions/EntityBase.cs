using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlowBuddie.Abstractions
{
    public class EntityBase : IEntity
    {
        [Key]
        [StringLength(128)]
        public virtual string Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:d}")]
        public virtual DateTimeOffset CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public virtual DateTimeOffset UpdatedAt { get; set; }

        [StringLength(70)]
        public virtual string CreatedBy { get; set; }

        [StringLength(70)]
        public virtual string UpdatedBy { get; set; }
    }
}
