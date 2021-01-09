using System;
using WeatherApp.Models;
using Xunit;

namespace WeatherAppTest.ModelTest
{
    public class FavoriteListModelTest
    {
        FavoriteListModel favoriteListModel = new FavoriteListModel();

        [Fact]
        public void MaxTempTest()
        {
            favoriteListModel.MaxTemp = "33.22";
            Assert.Equal("33.22", favoriteListModel.MaxTemp);
        }
        [Fact]
        public void MinTempTest()
        {
            favoriteListModel.MinTemp = "33.22";
            Assert.Equal("33.22", favoriteListModel.MinTemp);
        }
        [Fact]
        public void Temperature()
        {
            favoriteListModel.Temperature = "33.22";
            Assert.Equal("33.22", favoriteListModel.Temperature);
        }
        [Fact]
        public void ImageUrl()
        {
            favoriteListModel.ImageUrl = "www.image.com";
            Assert.Equal("www.image.com", favoriteListModel.ImageUrl);
        }


    }
}
