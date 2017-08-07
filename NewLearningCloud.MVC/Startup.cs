using Microsoft.Owin;
using Owin;
using NewLearningCloud.MVC;

[assembly: OwinStartup(typeof(Startup))]

namespace NewLearningCloud.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
