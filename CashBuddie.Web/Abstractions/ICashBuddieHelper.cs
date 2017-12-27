using CashBuddie.Web.Models;
using System.Threading.Tasks;

namespace CashBuddie.Web.Abstractions
{
    public interface ICashBuddieHelper
    {
        ICashBuddieHelper FilterOnContext(CashBuddieContext db);
        ICashBuddieHelper PrepareResultModel(InputModelBase message);
        ICashBuddieHelper SortBankAccountSet();
        ResultModelBase ToResultModel(int? pagesize);
    }
}