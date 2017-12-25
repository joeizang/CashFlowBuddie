using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashBuddie.Web.Models
{
    public class IndexInputModel
    {
        public string SortOrder { get; set; }

        public string SearchString { get; set; }

        public string CurrentFilter { get; set; }

        public int Page { get; set; }

    }
}