using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewJapaneseExam.Startup))]
namespace NewJapaneseExam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
