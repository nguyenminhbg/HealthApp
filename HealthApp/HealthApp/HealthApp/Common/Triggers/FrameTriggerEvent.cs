using Xamarin.Forms;

namespace HealthApp.Common.Triggers
{
    public class FrameTriggerEvent : TriggerAction<Frame>
    {
        protected override async void Invoke(Frame sender)
        {
            await sender.ScaleTo(0.95, 50, Easing.CubicInOut);
            await sender.ScaleTo(1, 50, Easing.CubicIn);
        }
    }
}
