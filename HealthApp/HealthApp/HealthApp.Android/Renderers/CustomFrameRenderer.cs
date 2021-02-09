using Android.Content;
using HealthApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//[assembly: Xamarin.Forms.ExportRenderer(typeof(Frame), typeof(CustomFrameRenderer))]
namespace HealthApp.Droid.Renderers
{
    public class CustomFrameRenderer: Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
    {
        public CustomFrameRenderer(Context context):base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            var element = e.NewElement as Frame;
            if (element == null) return;
            if (element.HasShadow)
            {
                Elevation = 30.0f;
                TranslationZ = 0.0f;
                SetZ(30f);
            }
        }
    }
}