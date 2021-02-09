using Android.Content;
using HealthApp.Custom;
using HealthApp.Droid.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(CustomProgressBar), typeof(CustomProgressBarRenderer))]
namespace HealthApp.Droid.Renderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public CustomProgressBarRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);
            Control.ScaleY = 2; //Changes the height
        }
    }
}