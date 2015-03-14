using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ccMVCTesting.Startup))]
namespace ccMVCTesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
