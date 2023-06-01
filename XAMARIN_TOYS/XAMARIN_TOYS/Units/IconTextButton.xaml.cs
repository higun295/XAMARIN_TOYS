using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace XAMARIN_TOYS.Units
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconTextButton : ContentView
    {
        public IconTextButton()
        {
            InitializeComponent();



            //icon.Data = IconPath;
            //text.Text = Text;

            //var tab = new TapGestureRecognizer();
            //tab.Tapped += (s, e) =>
            //{
            //    frame.BackgroundColor = Color.LightGray;
            //};
            ////tab.

            ////frame.GestureRecognizers.Add(tab);
        }

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create
        (
            nameof(CornerRadius),
            typeof(float),
            typeof(IconTextButton),
            default(float),
            BindingMode.OneWay
        );

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == CornerRadiusProperty.PropertyName)
            {
                frame.CornerRadius = CornerRadius;
            }
        }









        //public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(IconPath), typeof(Geometry), typeof(IconTextButton), default(string), BindingMode.OneWay);
        //[TypeConverter(typeof(PathGeometryConverter))]
        //public Geometry IconPath
        //{
        //    get { return (Geometry)GetValue(IconProperty); }
        //    set { SetValue(IconProperty, value); }
        //}

        //public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(IconTextButton), default(string), BindingMode.OneWay);
        //public string Text
        //{
        //    get { return (string)GetValue(TextProperty); }
        //    set { SetValue(TextProperty, value); }
        //}

        //protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    base.OnPropertyChanged(propertyName);

        //    if (propertyName == IconProperty.PropertyName)
        //    {
        //        icon.Data = IconPath;
        //    }
        //    else if (propertyName == TextProperty.PropertyName)
        //    {
        //        text.Text = Text;
        //    }
        //}
    }
}