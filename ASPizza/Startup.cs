using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPizza.Startup))]
namespace ASPizza
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
