using System;
using System.Collections.Generic;
using WeatherApp.Models;
using Xunit;

namespace WeatherAppTest.ModelTest
{
    public class WeatherModelTest
    {
        WeatherModel weatherModel = new WeatherModel();
        Coord coord = new Coord();
        Main main = new Main();
        Wind wind = new Wind();
        Clouds clouds = new Clouds();
        Sys sys = new Sys();
        Weather weather = new Weather();

        [Fact]
        public void VisibilityTest()
        {
            weatherModel.visibility = 1;
            Assert.Equal(1, weatherModel.visibility);
        }
        [Fact]
        public void MessageTest()
        {
            weatherModel.message = "Testing Message";
            Assert.Equal("Testing Message", weatherModel.message);
        }
        [Fact]
        public void BaseTest()
        {
            weatherModel.@base = "Testing Base";
            Assert.Equal("Testing Base", weatherModel.@base);
        }
        [Fact]
        public void CoordLatTest()
        {
            coord.lat = 12.34;
            Assert.Equal(12.34, coord.lat);
        }
        [Fact]
        public void CoordLonTest()
        {
            coord.lon = 12.34;
            Assert.Equal(12.34, coord.lon);
        }
        [Fact]
        public void MainTest()
        {
            main.feels_like = 23.34;
            main.humidity = 10;
            main.pressure = 12;
            main.temp_max = 34.12;
            main.temp_min = 23.12;
            main.temp = 23.34;

            Assert.Equal(23.34, main.feels_like);
            Assert.Equal(10, main.humidity);
            Assert.Equal(12, main.pressure);
            Assert.Equal(34.12, main.temp_max);
            Assert.Equal(23.12, main.temp_min);
            Assert.Equal(23.34, main.temp);
        }
        [Fact]
        public void WindTest()
        {
            wind.speed = 12.34;
            wind.deg = 1;

            Assert.Equal(12.34, wind.speed);
            Assert.Equal(1, wind.deg);
        }
        [Fact]
        public void DtTest()
        {
            weatherModel.dt = 23;
            Assert.Equal(23, weatherModel.dt);
        }
        [Fact]
        public void SysTest()
        {
            sys.country = "India";
            sys.sunrise = 5;
            sys.sunset = 6;
            sys.id = 1;
            sys.type = 3;

            Assert.Equal("India", sys.country);
            Assert.Equal(5, sys.sunrise);
            Assert.Equal(6, sys.sunset);
            Assert.Equal(1, sys.id);
            Assert.Equal(3, sys.type);
        }
        [Fact]
        public void TimeZoneTest()
        {
            weatherModel.timezone = 342;
            Assert.Equal(342, weatherModel.timezone);
        }
        [Fact]
        public void IdTest()
        {
            weatherModel.id = 342;
            Assert.Equal(342, weatherModel.id);
        }
        [Fact]
        public void NameTest()
        {
            weatherModel.name = "winter";
            Assert.Equal("winter", weatherModel.name);
        }
        [Fact]
        public void CODTest()
        {
            weatherModel.cod = 342;
            Assert.Equal(342, weatherModel.cod);
        }
        [Fact]
        public void WeatherListTest()
        {
            List<Weather> weatherList = new List<Weather>();
            weatherList.Add(new Weather
            {
                   id= 2,
                   main = "main",
                   description = "description",
                   icon = "50d"

            });
            Assert.NotEmpty(weatherList);
        }
    }
}

