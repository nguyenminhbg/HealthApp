using Android.Content;
using Android.Views.InputMethods;
using HealthApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(NotUnderlineEntry))]
namespace HealthApp.Droid.Renderers
{
    public class NotUnderlineEntry : EntryRenderer
    {
        public NotUnderlineEntry(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
            if (Control != null)
                Control.ImeOptions = (ImeAction)ImeFlags.NoExtractUi;
        }
    }
}