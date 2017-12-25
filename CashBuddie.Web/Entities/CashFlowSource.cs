using CashFlowBuddie.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace CashFlowBuddie.Web.Entities
{
    public class CashFlowSource : EntityBase
    {
        [DataType(DataType.Text)]
        [StringLength(128)]
        public string CashFlowSourceName { get; private set; }

    }
}