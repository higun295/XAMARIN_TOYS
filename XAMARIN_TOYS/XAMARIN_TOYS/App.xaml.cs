using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XAMARIN_TOYS
{
    public partial class App : Application
    {
        private static MainPage _mainPage;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        public static MainPage GetMainPage()
        {
            if (_mainPage == null)
            {
                _mainPage = new MainPage();
            }
            return _mainPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
