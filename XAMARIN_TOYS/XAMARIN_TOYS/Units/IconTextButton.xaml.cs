using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace XAMARIN_TOYS.Units
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconTextButton : ContentView
    {
        private bool _isPressed = false;

        public IconTextButton()
        {
            InitializeComponent();

            path.Data = IconPath;
            path.Fill = Fill;
            path.Stroke = Stroke;

            label.Text = Text;
            frame.CornerRadius = CornerRadius;

            var tab = new TapGestureRecognizer();
            tab.Tapped += (s, e) =>
            {
                if (_isPressed)
                {
                    _isPressed = false;
                    frame.BackgroundColor = Color.White;
                }
                else
                {
                    _isPressed = true;
                    frame.BackgroundColor = Color.LightGray;
                }
            };

            frame.GestureRecognizers.Add(tab);
        }

        public static readonly BindableProperty IconProperty = BindableProperty.Create
        (
            nameof(IconPath),
            typeof(Geometry),
            typeof(IconTextButton),
            default(string),
            BindingMode.OneWay
        );
        public static readonly BindableProperty TextProperty = BindableProperty.Create
        (
            nameof(Text),
            typeof(string),
            typeof(IconTextButton),
            default(string),
            BindingMode.OneWay
        );
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create
        (
            nameof(CornerRadius),
            typeof(float),
            typeof(IconTextButton),
            default(float),
            BindingMode.OneWay
        );
        public static readonly BindableProperty StrokeProperty = BindableProperty.Create
        (
            nameof(Stroke),
            typeof(Brush),
            typeof(IconTextButton),
            default(Brush),
            BindingMode.OneWay
        );
        public static readonly BindableProperty FillProperty = BindableProperty.Create
        (
            nameof(Fill),
            typeof(Brush),
            typeof(IconTextButton),
            default(Brush),
            BindingMode.OneWay
        );

        [TypeConverter(typeof(PathGeometryConverter))]
        public Geometry IconPath
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }
        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == CornerRadiusProperty.PropertyName)
            {
                frame.CornerRadius = CornerRadius;
            }
            else if (propertyName == IconProperty.PropertyName)
            {
                path.Data = IconPath;
            }
            else if (propertyName == TextProperty.PropertyName)
            {
                label.Text = Text;
            }
            else if (propertyName == StrokeProperty.PropertyName)
            {
                path.Stroke = Stroke;
            }
            else if (propertyName == FillProperty.PropertyName)
            {
                path.Fill = Fill;
            }
        }
    }
}