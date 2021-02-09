using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthApp.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await progressBar.ProgressTo(0.67, 500, Easing.Linear);
            await kcalProgress.ProgressTo(0.4, 500, Easing.Linear);
        }
    }
}