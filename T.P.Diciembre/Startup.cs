using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(T.P.Diciembre.Startup))]
namespace T.P.Diciembre
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
