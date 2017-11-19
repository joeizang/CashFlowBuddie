using System;
using CashFlowBuddie.Abstractions;
using CashFlowBuddie.Entities.ValueObjects;

namespace CashFlowBuddie.Entities
{
    public class CashFlow : EntityBase
    {
        public CashFlow()
        {

        }

        public string AccountId { get; private set; }

        public BankAccount BankAccount { get; private set; }

        public CashFlowSource CashFlowSouce { get; private set; }

        public string CashFlowSourceId { get; set; }

        public CashFlowType CashFlowType { get; private set; }

        public string CashFlowTypeId { get; private set; }

        public string UserId { get; private set; }

        public User User { get; set; }

        public Money Amount { get; private set; }
    }
}