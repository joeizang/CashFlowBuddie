using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CashBuddie.Web.Models.InputModels;
using System.ComponentModel.DataAnnotations;

namespace CashBuddie.Web.Models.InputModels
{
    public class BankAccountInputModel
    {
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }
        public int? Page { get; set; }

        public class BankAccountResultModel
        {
            public string CurrentSort { get; set; }
            public string NameSortParm { get; set; }
            public string DateSortParm { get; set; }
            public string CurrentFilter { get; set; }
            public string SearchString { get; set; }

            public IPagedList<BankAccountVM> Results { get; set; }
        }
    }

    public class BankAccountMessages
    {
        public string Message { get; set; }
    }

    public class CreateBankAccountModel
    {
        [Display(Name ="Account Balance")]
        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:C}")]
        public decimal AccountBalance { get; set; }

        [Display(Name ="Account Name")]
        [Required]
        [DataType(DataType.Text)]
        public string NameOfAccount { get; set; }

        [Display(Name = "Institution Name")]
        [Required]
        [DataType(DataType.Text)]
        public string InstitutionName { get; set; }

        [Display(Name = "Account Number")]
        [Required]
        [RegularExpression(@"^[0-9]{10,10}$",ErrorMessage ="Your Account Number must be a NUBAN 10 Digit Account Number")]
        public string AccountNumber { get; set; }
    }

    public class BankAccountDetailModel
    {
        public string Id { get; set; }

        public decimal AccountBalance { get; set; }

        public string BankAccountNumber { get; set; }

        public List<CashFlowVM> Transactions { get; set; }


        public class BankAccountDetailInputModel
        {
            
            public string Id { get; set; }
        }

    }


    public class BankAccountEditModel
    {

        [Required]
        public string Id { get; set; }

        [Display(Name = "Account Balance")]
        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public decimal AccountBalance { get; set; }

        [Display(Name = "Account Name")]
        [Required]
        [DataType(DataType.Text)]
        public string NameOfAccount { get; set; }

        [Display(Name = "Institution Name")]
        [Required]
        [DataType(DataType.Text)]
        public string InstitutionName { get; set; }

        [Display(Name = "Account Number")]
        [Required]
        [RegularExpression(@"^[0-9]{10,10}$", ErrorMessage = "Your Account Number must be a NUBAN 10 Digit Account Number")]
        public string AccountNumber { get; set; }

        public class BankAccountEditInputModel
        {
            [Required]
            public string Id { get; set; }
        }
    }

    public class BankAccountDeleteModel
    {
        public string Id { get; set; }

        public string Message { get; set; }

        public string AccountName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d2}")]
        public decimal BankBalance { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string InstitutionName { get; set; }
    }

    public class BankAccountVM
    {
        public decimal Amount { get; set; }

        public string InstitutionName { get; set; }

        public string BankAccountNumber { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public string Id { get; set; }
    }
}