using System;
using WeatherApp.Models;
using Xunit;

namespace WeatherAppTest.ModelTest
{
    public class WeatherListModelTest
    {
        WeatherListModel weatherListModel = new WeatherListModel();

        [Fact]
        public void MaxTempTest()
        {
            weatherListModel.MaxTemp = "33.22";
            Assert.Equal("33.22", weatherListModel.MaxTemp);
        }
        [Fact]
        public void MinTempTest()
        {
            weatherListModel.MinTemp = "33.22";
            Assert.Equal("33.22", weatherListModel.MinTemp);
        }
        [Fact]
        public void Temperature()
        {
            weatherListModel.Temperature = "33.22";
            Assert.Equal("33.22", weatherListModel.Temperature);
        }
        [Fact]
        public void ImageUrl()
        {
            weatherListModel.ImageUrl = "www.image.com";
            Assert.Equal("www.image.com", weatherListModel.ImageUrl);
        }
    }
}
