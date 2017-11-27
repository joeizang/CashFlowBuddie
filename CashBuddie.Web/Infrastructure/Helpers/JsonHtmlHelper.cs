using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CashBuddie.Web.Infrastructure.Extensions;

namespace CashBuddie.Web.Infrastructure.Helpers
{
    public static class JsonHtmlHelper
    {
        public static IHtmlString JsonFor<T>(this HtmlHelper helper, T obj)
        {
            return helper.Raw(obj.MakeJson());
        }
    }
}