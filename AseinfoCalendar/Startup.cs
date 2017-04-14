using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AseinfoCalendar.Startup))]
namespace AseinfoCalendar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
