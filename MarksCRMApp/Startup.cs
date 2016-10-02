using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarksCRMApp.Startup))]
namespace MarksCRMApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
