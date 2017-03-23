using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImagePicker.Startup))]
namespace ImagePicker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
