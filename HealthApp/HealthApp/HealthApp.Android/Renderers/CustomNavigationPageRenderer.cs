using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HealthApp.Custom;
using HealthApp.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationPageRenderer))]
namespace HealthApp.Droid.Renderers
{
   public class CustomNavigationPageRenderer: NavigationPageRenderer
    {
        public CustomNavigationPageRenderer(Context context) : base(context)
        {

        }
        protected override void SetupPageTransition(AndroidX.Fragment.App.FragmentTransaction transaction, bool isPush)
        {
            if (isPush)
            {
                transaction.SetCustomAnimations(Resource.Animator.enter_right, Resource.Animator.exit_left,
                                                Resource.Animator.enter_left, Resource.Animator.exit_right);
            }
            else
            {
                transaction.SetCustomAnimations(Resource.Animator.enter_left, Resource.Animator.exit_right,
                                                Resource.Animator.enter_right, Resource.Animator.exit_left);
            }
        }
    }
}