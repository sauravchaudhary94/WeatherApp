using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Config;
using WeatherApp.Interface;
using Xamarin.Forms;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherDetails
    {
        AppConfig AppConfig;
        public WeatherService()
        {
            AppConfig = DependencyService.Resolve<IConfigurationManager>().AppConfig;
        }

        public async Task<string> GetWeatherDetailsByCityName(string baseurl, string cityName, string APIKey)
        {
            var result = "";
            try
            {
                if (string.IsNullOrEmpty(baseurl))
                {
                    baseurl = AppConfig.WeatherUrlByCity;
                }
                var url = string.Format(baseurl, cityName, APIKey);

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    result = await response.Content.ReadAsStringAsync();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }

        public async Task<string> GetWeatherDetailsByZIP(string baseurl, string ZIP, string APIKey)
        {
            var result = "";
            try
            {
                if (string.IsNullOrEmpty(baseurl))
                {
                    baseurl = AppConfig.WeatherUrlByZip;
                }
                var url = string.Format(baseurl, ZIP, APIKey);

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    result = await response.Content.ReadAsStringAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;

        }
    }
}
