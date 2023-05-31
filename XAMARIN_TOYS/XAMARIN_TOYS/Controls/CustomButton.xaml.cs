using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace XAMARIN_TOYS.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomButton : ContentView
    {
        public event EventHandler Clicked;

        public static readonly BindableProperty ButtonText = BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomButton));

        public string Text
        {
            get => (string)GetValue(ButtonText);
            set => SetValue(ButtonText, value);
        }

        public static readonly BindableProperty ButtonImage = BindableProperty.Create(nameof(Image), typeof(Geometry), typeof(CustomButton));

        [TypeConverter(typeof(PathGeometryConverter))]
        public Geometry Image
        {
            get => (Geometry)GetValue(ButtonImage);
            set => SetValue(ButtonImage, value);
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command),
            typeof(ICommand), typeof(CustomButton), null);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandPropertyParam = BindableProperty.Create(nameof(CommandParam),
            typeof(object), typeof(CustomButton), null);

        public object CommandParam
        {
            get => (object)GetValue(CommandPropertyParam);
            set => SetValue(CommandPropertyParam, value);
        }

        public CustomButton()
        {
            InitializeComponent();
            BindingContext = this;

            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Clicked?.Invoke(this, EventArgs.Empty);
                    if (Command != null)
                    {
                        if (Command.CanExecute(CommandParam))
                            Command.Execute(CommandParam);
                    }
                })
            });
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            btnIcon.Data = Image;
            btnText.Text = Text;
        }
    }
}