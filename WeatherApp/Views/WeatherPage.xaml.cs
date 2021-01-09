using System;
using System.Collections.Generic;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class WeatherPage : ContentPage
    {
        private WeatherViewModel weatherViewModel;
        public WeatherPage()
        {
            InitializeComponent();
            weatherViewModel = new WeatherViewModel(Navigation);
            BindingContext = weatherViewModel;
        }
        public void Handle_Focused(object sender, FocusEventArgs e)
        {
            if (e.IsFocused)
            {
                SearchEntry.VerticalOptions = LayoutOptions.Start;
            }
        }

        public void Handle_Unfocused(object sender, FocusEventArgs e)
        {
            if (e.IsFocused)
            {
                SearchEntry.VerticalOptions = LayoutOptions.Start;
            }

        }
    }
}
