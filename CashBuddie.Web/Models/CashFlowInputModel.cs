using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashBuddie.Web.Models
{
    public class CashFlowInputModel
    {
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }
        public int? Page { get; set; }

        public class CashFlowResultModel
        {
            public string CurrentSort { get; set; }
            public string NameSortParm { get; set; }
            public string DateSortParm { get; set; }
            public string CurrentFilter { get; set; }
            public string SearchString { get; set; }

            public IPagedList<CashFlowVM> Results { get; set; }
        }

        public class CashFlowVM
        {
            public decimal Amount { get; set; }

            public string CashFlowTypeName { get; set; }

            public string CashFlowSourceName { get; set; }

            public string BankAccountNumber { get; set; }

            public DateTimeOffset CreatedDate { get; set; }
        }
    }
}