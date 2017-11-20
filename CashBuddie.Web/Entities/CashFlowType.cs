using CashFlowBuddie.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace CashFlowBuddie.Web.Entities
{
    public class CashFlowType : EntityBase
    {
        [DataType(DataType.Text)]
        [StringLength(128)]
        public string TypeName { get; private set; }

        [DataType(DataType.Text)]
        [StringLength(300)]
        public string Description { get; private set; }

    }
}