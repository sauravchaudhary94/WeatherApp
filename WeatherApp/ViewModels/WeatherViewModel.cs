using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using WeatherApp.Config;
using WeatherApp.Interface;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Views;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        IWeatherDetails weatherDetails;
        AppConfig AppConfig;
        INavigation _navigation;
        WeatherListModel weatherListModelObj;
        private ObservableCollection<WeatherListModel> _weatherListModel;
        public ObservableCollection<WeatherListModel> weatherListModel
        {
            get { return _weatherListModel; }
            set
            {
                SetProperty(ref _weatherListModel, value);
            }
        }
       
        private string editorText;
        public string SearchText
        {
            get => editorText;
            set => SetProperty(ref editorText, value);
        }
        bool _isVisible;
        public bool IsListVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }
        bool _isFavoriteListVisible;
        public bool IsFavoriteListVisible
        {
            get => _isFavoriteListVisible;
            set => SetProperty(ref _isFavoriteListVisible, value);
        }
        bool _isProgressBarVisible;
        public bool IsProgressBarVisible
        {
            get => _isProgressBarVisible;
            set => SetProperty(ref _isProgressBarVisible, value);
        }
        FavoriteListModel favoriteListModel = new FavoriteListModel();
        public ICommand SearchClicked => new Command(async () => await OnSearchClicked());
        public ICommand AddClicked => new Command(async () => await OnAddClicked());
        public ICommand ViewClicked => new Command(async () => await OnViewClicked());
        public WeatherViewModel(INavigation navigation)
        {
            _navigation = navigation;
            weatherListModelObj = new WeatherListModel();
            weatherListModel = new ObservableCollection<WeatherListModel>();
            IsListVisible = false;
            IsProgressBarVisible = false;
            AppConfig = DependencyService.Resolve<IConfigurationManager>().AppConfig;
            weatherDetails = DependencyService.Resolve<IWeatherDetails>();
        }

        public async Task OnSearchClicked()
        {
            WeatherModel weatherDetailsModel = new WeatherModel();
            weatherListModel.Clear();
            IsProgressBarVisible = true;
            if(editorText.All(char.IsDigit))
            {
                weatherDetailsModel = await GetWeatherDetailsByZip(editorText);
                if(string.IsNullOrEmpty(weatherDetailsModel.message))
                {
                    IsProgressBarVisible = false;
                    IsListVisible = true;
                    weatherListModelObj.MaxTemp = "Max Temp:" + "  " + weatherDetailsModel.main.temp_max + "°C";
                    weatherListModelObj.MinTemp = "Min Temp:" + "  " + weatherDetailsModel.main.temp_min + "°C";
                    weatherListModelObj.Temperature = "Temperature:" + "  " + weatherDetailsModel.main.temp + "°C";
                    weatherListModelObj.ImageUrl = "https://e7.pngegg.com/pngimages/480/79/png-clipart-sky-cloud-icon-cloudy-weather-icon-material-text-camera-icon.png";
                    weatherListModel.Add(new WeatherListModel
                    {
                        MaxTemp = weatherListModelObj.MaxTemp,
                        MinTemp = weatherListModelObj.MinTemp,
                        Temperature = weatherListModelObj.Temperature,
                        ImageUrl = weatherListModelObj.ImageUrl
                    });
                }
                else
                {
                    IsProgressBarVisible = false;
                    await App.Current.MainPage.DisplayAlert(editorText, "Entered PinCode is not available", "Ok");
                }
            }
            else if(editorText.All(char.IsLetter))
            {
                weatherDetailsModel = await GetWeatherDetailsByCity(editorText);
                if (string.IsNullOrEmpty(weatherDetailsModel.message))
                {
                    IsProgressBarVisible = false;
                    IsListVisible = true;
                    weatherListModelObj.MaxTemp = "Max Temp:" + "  " + weatherDetailsModel.main.temp_max + "°C";
                    weatherListModelObj.MinTemp = "Min Temp:" + "  " + weatherDetailsModel.main.temp_min + "°C";
                    weatherListModelObj.Temperature = "Temperature:" + "  " + weatherDetailsModel.main.temp + "°C";
                    weatherListModelObj.ImageUrl = "https://e7.pngegg.com/pngimages/480/79/png-clipart-sky-cloud-icon-cloudy-weather-icon-material-text-camera-icon.png";
                    weatherListModel.Add(new WeatherListModel
                    {
                        MaxTemp = weatherListModelObj.MaxTemp,
                        MinTemp = weatherListModelObj.MinTemp,
                        Temperature = weatherListModelObj.Temperature,
                        ImageUrl = weatherListModelObj.ImageUrl
                    });

                }
                else
                {
                    IsProgressBarVisible = false;
                    await App.Current.MainPage.DisplayAlert(editorText, "Entered City is not available", "Ok");
                }
            }
            else
            {
                IsProgressBarVisible = false;
                await App.Current.MainPage.DisplayAlert("Invalid Input", "Please enter valid city name or Zip", "Ok");
            }

        }

        public async Task OnAddClicked()
        {
            IsFavoriteListVisible = true;
           
            favoriteListModel.MaxTemp = weatherListModelObj.MaxTemp;
            favoriteListModel.MinTemp = weatherListModelObj.MinTemp;
            favoriteListModel.Temperature = weatherListModelObj.Temperature;
            favoriteListModel.ImageUrl = weatherListModelObj.ImageUrl;

            await _navigation.PushAsync(new FavoritePage(favoriteListModel));
        }

        public async Task OnViewClicked()
        {
             if(string.IsNullOrEmpty(favoriteListModel.MaxTemp) || string.IsNullOrEmpty(favoriteListModel.MinTemp)|| string.IsNullOrEmpty(favoriteListModel.Temperature)
                || string.IsNullOrEmpty(favoriteListModel.ImageUrl))
              {
                await App.Current.MainPage.DisplayAlert("No FavoriteList Found", "No Item is in the favorite List.", "Ok");
               
              }
              else
              {
                IsFavoriteListVisible = true;
                await _navigation.PushAsync(new FavoritePage(favoriteListModel));
            } 

        }

        public async  Task<WeatherModel> GetWeatherDetailsByCity(string cityName)
        {
            var response = await weatherDetails.GetWeatherDetailsByCityName(AppConfig.WeatherUrlByCity, cityName,AppConfig.ApiKey);

             WeatherModel weatherModel = JsonConvert.DeserializeObject<WeatherModel>(response);

             return weatherModel;
        }

        public async  Task<WeatherModel> GetWeatherDetailsByZip(string ZIP)
        {
            WeatherModel weatherModel = new WeatherModel();
            var response = await weatherDetails.GetWeatherDetailsByCityName(AppConfig.WeatherUrlByZip, ZIP, AppConfig.ApiKey);
            weatherModel = JsonConvert.DeserializeObject<WeatherModel>(response);

            return weatherModel;
        }

    }
}
