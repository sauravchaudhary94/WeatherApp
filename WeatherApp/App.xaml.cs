using System;
using WeatherApp.Config;
using WeatherApp.Interface;
using WeatherApp.Services;
using WeatherApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RegisterServices();
            MainPage = new NavigationPage(new WeatherPage());
        }
        private void RegisterServices()
        {
            DependencyService.Register<IConfigurationManager, ConfigurationManager>();
            DependencyService.Register<IWeatherDetails,WeatherService> ();
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
