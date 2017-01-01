using Nancy;

namespace Warden.Services.Organizations.Modules
{
    public class HomeModule : ModuleBase
    {
        public HomeModule()
        {
            Get("", args => "Welcome to the Warden.Services.Organizations API!");
        }
    }
}