using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Laboratorio5.Startup))]
namespace Laboratorio5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            

            ConfigureAuth(app);

            

        }
    }
}
