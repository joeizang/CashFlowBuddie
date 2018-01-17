using CashBuddie.Web.Abstractions;
using CashFlowBuddie.Web.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CashBuddie.Web.Models.InputModels
{
    public class CashFlowInputModel : InputModelBase
    {


    }

    public class CashFlowResultModel : ResultModelBase
    {
        public IPagedList<CashFlowVM> Results { get; set; }
    }

    public class CashFlowDetailModel
    {
        public string Id { get; set; }

        public CashFlowSourceVM CashFlowSource { get; set; }

        public CashFlowTypeVM CashFlowType { get; set; }

        public decimal Amount { get; set; }

        public DateTimeOffset Date { get; set; }

        public string BankAccountName { get; set; }

        public string BankAccountNumber { get; set; }
    }

    public class CreateCashFlowModel
    {
        [StringLength(128)]
        public string AccountId { get;  set; }


        public BankAccountVM BankAccount { get;  set; }

        public CashFlowSourceVM CashFlowSouce { get;  set; }

        [DataType(DataType.Text)]
        [StringLength(128)]
        public string CashFlowSourceId { get;  set; }

        public CashFlowTypeVM CashFlowType { get;  set; }

        [DataType(DataType.Text)]
        [StringLength(128)]
        public string CashFlowTypeId { get;  set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get;  set; }

        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Description { get; set; }
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