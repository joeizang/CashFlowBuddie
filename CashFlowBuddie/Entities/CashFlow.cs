﻿using System;
using System.ComponentModel.DataAnnotations;
using CashFlowBuddie.Abstractions;
using CashFlowBuddie.Models;

namespace CashFlowBuddie.Entities
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

        public ApplicationUser User { get; private set; }
    }
}