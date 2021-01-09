using System;
using System.Threading.Tasks;

namespace WeatherApp.Interface
{
    public interface IWeatherDetails
    {
        Task<string> GetWeatherDetailsByCityName(string baseurl, string cityName, string APIKey);
        Task<string> GetWeatherDetailsByZIP(string baseurl, string ZIP, string APIKey);
    }
}
