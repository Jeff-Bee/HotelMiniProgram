using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JeffBee.HotelMiniProgram.Web.Startup))]
namespace JeffBee.HotelMiniProgram.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
