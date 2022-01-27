using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetTest.Startup))]
namespace DotNetTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
