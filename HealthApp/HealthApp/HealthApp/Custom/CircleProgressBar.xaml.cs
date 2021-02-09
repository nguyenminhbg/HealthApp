using Xamarin.Forms.Xaml;

namespace HealthApp.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CircleProgressBar : XFCircleProgress
    {
        public CircleProgressBar()
        {
            InitializeComponent();
        }
    }
}