using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pravina.Startup))]
namespace Pravina
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
