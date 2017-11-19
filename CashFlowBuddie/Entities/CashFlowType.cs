using CashFlowBuddie.Abstractions;

namespace CashFlowBuddie.Entities
{
    public class CashFlowType : EntityBase
    {
        public string TypeName { get; private set; }

        public string Description { get; private set; }

    }
}