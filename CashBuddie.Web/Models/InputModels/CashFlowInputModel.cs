using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashBuddie.Web.Models.InputModels
{
    public class CashFlowInputModel
    {

        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }
        public int? Page { get; set; }

    }

    public class CashFlowIndexResult
    {
        public string CurrentSort { get; set; }
        public string NameSortParm { get; set; }
        public string DateSortParm { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }

        public IPagedList<CashFlowVM> CashFlowResults { get; set; }
    }

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