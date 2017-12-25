using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CashBuddie.Web.Startup))]
namespace CashBuddie.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
