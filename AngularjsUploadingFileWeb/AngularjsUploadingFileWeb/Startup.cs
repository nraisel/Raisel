using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularjsUploadingFileWeb.Startup))]
namespace AngularjsUploadingFileWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
