using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(INF272_Deliverable_2.Startup))]
namespace INF272_Deliverable_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
