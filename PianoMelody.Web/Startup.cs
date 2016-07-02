using Microsoft.Owin;

[assembly: OwinStartup(typeof(PianoMelody.Web.Startup))]

namespace PianoMelody.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}