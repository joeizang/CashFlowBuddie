using CashFlowBuddie.Abstractions;
using CashFlowBuddie.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlowBuddie.Entities
{
    public class BankAccount : EntityBase
    {

        public BankAccount()
        {

        }

        public string AccountName { get; private set; }

        public Money BankBalance { get; private set; }


        public ICollection<CashFlow> CashFlows { get; private set; }

        public User AccountHolder { get; private set; }

        public string UserId { get; private set; }
    }
}
