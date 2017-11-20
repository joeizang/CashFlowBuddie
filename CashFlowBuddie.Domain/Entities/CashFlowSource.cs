using CashFlowBuddie.Data.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace CashFlowBuddie.Domain.Entities
{
    public class CashFlowSource : EntityBase
    {
        [DataType(DataType.Text)]
        [StringLength(128)]
        public string CashFlowSourceName { get; private set; }

    }
}