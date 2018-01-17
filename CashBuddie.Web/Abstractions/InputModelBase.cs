namespace CashBuddie.Web.Abstractions
{
    public abstract class InputModelBase
    {
        public string CurrentFilter { get; set; }
        public int? Page { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
    }
}