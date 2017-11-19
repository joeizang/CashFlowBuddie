using CashFlowBuddie.Abstractions;
using System.Collections.Generic;

namespace CashFlowBuddie.Entities
{
    public class User : EntityBase
    {
        public string EmailAddress { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string OtherNames { get; private set; } //TODO FINISH MODELLING THE USER COS USER = APPUSER

        public ICollection<CashFlow> CashFlows { get; set; }
    }
}