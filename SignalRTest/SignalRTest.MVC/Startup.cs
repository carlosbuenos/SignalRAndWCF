using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRTest.MVC.Startup))]
namespace SignalRTest.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
