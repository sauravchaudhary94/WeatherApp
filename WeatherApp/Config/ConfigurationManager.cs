using System;
using System.IO;
using System.Reflection;
using WeatherApp.Interface;

namespace WeatherApp.Config
{
    public class ConfigurationManager : IConfigurationManager
    {
       
        public ConfigurationManager()
        {
            ReloadConfig();
        }

        public AppConfig AppConfig { get; set; }

        public void ReloadConfig()
        {
            Stream stream = null;

            try
            {
                var configFileName = $"WeatherAPI.json";
                stream = this.GetType().Assembly.GetManifestResourceStream($"WeatherApp.Config.{configFileName}");

                using (StreamReader sr = new StreamReader(stream))
                {
                    var jsongStr = sr.ReadToEnd();
                    
                    AppConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<AppConfig>(jsongStr);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }

        }
    }
}
