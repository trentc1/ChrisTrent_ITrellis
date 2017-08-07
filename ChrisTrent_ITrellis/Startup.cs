using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChrisTrent_ITrellis.Startup))]
namespace ChrisTrent_ITrellis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
