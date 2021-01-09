using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using Moq;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xunit;


namespace WeatherAppTest.ViewModelTest
{
    public class WeatherViewModelTest
    {
        private WeatherViewModel weatherViewModel;
        INavigation _navigation;

        public WeatherViewModelTest()
        {
            MockForms.Init();
            _navigation = A.Fake<INavigation>();
            weatherViewModel = new WeatherViewModel(_navigation);
        
        }

        [Fact]
        public void SearchTextTest()
        {
            bool invoked = false;
            weatherViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals("SearchText"))
                    invoked = true;
            }; 
            weatherViewModel.SearchText = "Test";

            Assert.True(invoked);
            Assert.True(weatherViewModel.SearchText == "Test");
        }

        [Fact]
        public void IsListVisibleTest()
        {
            bool invoked = false;
            weatherViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals("IsListVisible"))
                    invoked = true;
            };
            weatherViewModel.IsListVisible = true;

            Assert.True(invoked);
            Assert.True(weatherViewModel.IsListVisible);
        }

        [Fact]
        public void IsFavoriteListVisibleTest()
        {
            bool invoked = false;
            weatherViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals("IsFavoriteListVisible"))
                    invoked = true;
            };
            weatherViewModel.IsFavoriteListVisible = true;

            Assert.True(invoked);
            Assert.True(weatherViewModel.IsFavoriteListVisible);
        }

        [Fact]
        public void IsProgressBarVisibleTest()
        {
            bool invoked = false;
            weatherViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals("IsProgressBarVisible"))
                    invoked = true;
            };
            weatherViewModel.IsProgressBarVisible = true;

            Assert.True(invoked);
            Assert.True(weatherViewModel.IsProgressBarVisible);

        }

    }
}
