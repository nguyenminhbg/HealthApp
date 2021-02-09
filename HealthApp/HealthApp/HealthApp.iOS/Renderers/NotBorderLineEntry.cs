using CoreAnimation;
using HealthApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(NotBorderLineEntry))]
namespace HealthApp.iOS.Renderers
{
    public class NotBorderLineEntry : EntryRenderer
    {
        private CALayer _line;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            _line = null;
            if (Control == null || e.NewElement == null)
                return;
            Control.BorderStyle = UITextBorderStyle.None;
            Control.Layer.BorderWidth = 0;
        }
    }
}