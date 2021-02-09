using CoreGraphics;
using HealthApp.Custom;
using HealthApp.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.ExportRenderer(typeof(CustomProgressBar), typeof(CustomProgressBarRenderer))]

namespace HealthApp.iOS.Renderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var X = 1.0f;
            var Y = 10.0f; // This changes the height

            CGAffineTransform transform = CGAffineTransform.MakeScale(X, Y);
            Control.Transform = transform;
        }
    }
}