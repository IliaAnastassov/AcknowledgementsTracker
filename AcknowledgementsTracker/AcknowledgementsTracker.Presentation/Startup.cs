using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcknowledgementsTracker.Presentation.Startup))]
namespace AcknowledgementsTracker.Presentation
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
