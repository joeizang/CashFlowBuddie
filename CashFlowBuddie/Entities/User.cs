using CashFlowBuddie.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashFlowBuddie.Entities
{
    public class User : EntityBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must provide a valid email address to continue")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must provide a first name to continue")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string FirstName { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must provide a last name to continue")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string LastName { get; private set; }

        [DataType(DataType.Text)]
        [StringLength(30)]
        public string OtherNames { get; private set; }

        [StringLength(150)]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must provide a password to continue")]
        public string Password { get; private set; }

        [StringLength(11)]
        public string MobileNumber { get; private set; }

        public ICollection<CashFlow> CashFlows { get; private set; }

        public ICollection<BankAccount> Accounts { get; private set; }

    }
}
