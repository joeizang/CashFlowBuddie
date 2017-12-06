using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashBuddie.Web.Models.InputModels
{
    public class CashFlowInputModel
    {


        public class CashFlowVM
        {
            public string Id { get; set; }

            public string Source { get; set; }

            public string Type { get; set; }

            public decimal Amount { get; set; }

            public DateTimeOffset CashActivityDate { get; set; }

            public string BankAccountId { get; set; }

        }
    }
}