using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace HealthApp.Custom
{
    public class CustomNavigationPage: Xamarin.Forms.NavigationPage
    {
        public CustomNavigationPage(Xamarin.Forms.Page root) : base(root)
        {
            BarTextColor = Color.White;
            BarBackgroundColor = Color.FromHex("#089BAB");
            On<iOS>()
                .SetStatusBarTextColorMode(StatusBarTextColorMode.MatchNavigationBarTextLuminosity);
        }
    }
}
