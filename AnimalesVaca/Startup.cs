using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimalesVaca.Startup))]
namespace AnimalesVaca
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
