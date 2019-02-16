using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CreativeBox.Startup))]
namespace CreativeBox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
