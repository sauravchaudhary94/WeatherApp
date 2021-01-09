using System;
using System.IO;
using WeatherApp.Config;
using WeatherApp.Interface;

namespace WeatherAppTest
{
    public class MockConfigurationManager : IConfigurationManager
    {

        public MockConfigurationManager()
        {
            ReloadConfig();
        }

        public AppConfig AppConfig { get; set; }
       // AppConfig IConfigurationManager.AppConfig { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
