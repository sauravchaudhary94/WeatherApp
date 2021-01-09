using System;
using WeatherApp.Config;

namespace WeatherApp.Interface
{
    public interface IConfigurationManager
    {
        AppConfig AppConfig { get; set; }
        void ReloadConfig();
    }
}
