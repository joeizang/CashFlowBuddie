using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashBuddie.Web.Abstractions
{
    public abstract class ResultModelBase
    {
        public string CurrentSort { get; set; }
        public string NameSortParm { get; set; }
        public string DateSortParm { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }
    }
}