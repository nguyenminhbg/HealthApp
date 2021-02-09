using CoreAnimation;
using HealthApp.Custom;
using HealthApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationPageRenderer))]
namespace HealthApp.iOS.Renderers
{
    public class CustomNavigationPageRenderer: NavigationRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            NavigationBar.SetBackgroundImage(new UIKit.UIImage(), UIKit.UIBarMetrics.Default);
            NavigationBar.ShadowImage = new UIKit.UIImage();
        }
        public override void PushViewController(UIViewController viewController, bool animated)
        {
            var transition = CATransition.CreateAnimation();
            transition.Duration = 0.1f;
            transition.Type = CAAnimation.TransitionPush;
            transition.Subtype = CAAnimation.TransitionFromRight;
            View.Layer.AddAnimation(transition, null);
            base.PushViewController(viewController, false);
        }

        public override UIViewController PopViewController(bool animated)
        {
            var transition = CATransition.CreateAnimation();
            transition.Duration = 0.1f;
            transition.Type = CAAnimation.TransitionPush;
            transition.Subtype = CAAnimation.TransitionFromLeft;
            View.Layer.AddAnimation(transition, null);
            return base.PopViewController(false);
        }
    }
}