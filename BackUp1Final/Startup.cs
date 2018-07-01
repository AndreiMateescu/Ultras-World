using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BackUp1Final.Startup))]
namespace BackUp1Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
