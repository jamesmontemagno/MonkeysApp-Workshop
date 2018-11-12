using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MonkeyAppServer.Startup))]

namespace MonkeyAppServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}