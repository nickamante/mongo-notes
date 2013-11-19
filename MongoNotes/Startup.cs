using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MongoNotes.Startup))]
namespace MongoNotes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
