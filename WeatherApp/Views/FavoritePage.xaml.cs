using System;
using System.Collections.Generic;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class FavoritePage : ContentPage
    {
        private FavoriteListModel _favoriteListModel;
        public FavoritePage(FavoriteListModel favoriteListModel)
        {
            InitializeComponent();
            _favoriteListModel = favoriteListModel;
            BindingContext = new FavoriteListViewModel(_favoriteListModel);
        }
    }
}
