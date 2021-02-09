using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthApp.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonInfo : Grid
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
          nameof(Title),
          typeof(string),
          typeof(ButtonInfo),
          default(string),
          BindingMode.TwoWay
          );


        public string Title
        {
            set => SetValue(TitleProperty, value);
            get => (string)GetValue(TitleProperty);
        }
        public static BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(ButtonInfo),
             null,
            BindingMode.TwoWay, propertyChanged: HandleTextChanged
            );

        private static void HandleTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is Entry view && newValue is string str)
            {
                view.Text = str;
            }
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        public ButtonInfo()
        {
            InitializeComponent();
            btnTitle.BindingContext = this;
            var t = Title;
          //  BindingContext = this;
            var txt = btnTitle.Text;
          //  btnTitle.Text = Title;
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
                Command?.Execute(sender);
        }
    }
}