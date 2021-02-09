
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthApp.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomEntry : Frame
    {
        public static BindableProperty PlaceHoldProperty = BindableProperty.Create(
            nameof(PlaceHold),
            typeof(string),
            typeof(CustomEntry),
            default(string),
            BindingMode.TwoWay
            );
        public string PlaceHold
        {
            get => (string)GetValue(PlaceHoldProperty);
            set => SetValue(PlaceHoldProperty, value);
        }

        public static BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(CustomEntry),
            default(string),
            BindingMode.TwoWay
            );
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly BindableProperty ImageSourceEntryProperty =
    BindableProperty.Create(nameof(ImageSourceEntry), typeof(ImageSource), typeof(CustomEntry), null, BindingMode.TwoWay);
        public ImageSource ImageSourceEntry
        {
            get => (ImageSource)GetValue(ImageSourceEntryProperty);
            set => SetValue(ImageSourceEntryProperty, value);
        }
        public CustomEntry()
        {
            InitializeComponent();
            entryCustom.BindingContext = this;
        }
    }
}