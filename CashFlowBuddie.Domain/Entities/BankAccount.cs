﻿using CashFlowBuddie.Data.Abstractions;
using CashFlowBuddie.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlowBuddie.Domain.Entities
{
    public class BankAccount : EntityBase
    {

        public BankAccount()
        {
            CashFlows = new List<CashFlow>();
        }

        [DataType(DataType.Text)]
        [StringLength(50)]
        public string AccountName { get; private set; }

        public Money BankBalance { get; private set; }


        public ICollection<CashFlow> CashFlows { get; private set; }

        public User AccountHolder { get; private set; }

        [DataType(DataType.Text)]
        [StringLength(128)]
        public string UserId { get; private set; }
    }
}