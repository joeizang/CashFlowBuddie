using System;
using System.ComponentModel.DataAnnotations;
using CashFlowBuddie.Data.Abstractions;
using CashFlowBuddie.Domain.Entities.ValueObjects;

namespace CashFlowBuddie.Domain.Entities
{
    public class CashFlow : EntityBase
    {
        public CashFlow()
        {

        }

        [DataType(DataType.Text)]
        [StringLength(128)]
        public string AccountId { get; private set; }

        public BankAccount BankAccount { get; private set; }

        public CashFlowSource CashFlowSouce { get; private set; }

        [DataType(DataType.Text)]
        [StringLength(128)]
        public string CashFlowSourceId { get; private set; }

        public CashFlowType CashFlowType { get; private set; }

        [DataType(DataType.Text)]
        [StringLength(128)]
        public string CashFlowTypeId { get; private set; }

        [DataType(DataType.Text)]
        [StringLength(128)]
        public string UserId { get; private set; }

        public User User { get; private set; }

        public Money Amount { get; private set; }
    }
}