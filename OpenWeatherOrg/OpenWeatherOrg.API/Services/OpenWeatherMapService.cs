using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWeatherOrg.API.Model;
using OpenWeatherOrg.API.Interfaces;

namespace OpenWeatherOrg.API.Services
{
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public WeatherModel GetData(string cityName)
        {
            WeatherModel retval = new WeatherModel();
            IsError = false;
            try
            {
                string baseUrl = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}";
                string token = "4a8c15882ab8422513128083d12bc6f8";

                WebRequest request = WebRequest.Create(string.Format(baseUrl, cityName, token));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string dataReader = reader.ReadToEnd();

                var _json = JsonConvert.DeserializeObject<OpenWeatherMapClass>(dataReader);

                reader.Close();
                dataStream.Close();
                response.Close();
                //string  = JsonConvert.SerializeObject(_json);

                retval.dewPoint = _json.main.feels_like.ToString();
                retval.location = string.Format("lon: {0} ,lat: {1}", _json.coord.lon, _json.coord.lat);
                retval.pressure = _json.main.pressure.ToString();
                retval.relativeHumidity = _json.main.humidity.ToString();
                retval.skyConditions = string.Format("{0}, {1}", _json.weather[0].main, _json.weather[0].description);
                retval.temperatureCelsius = string.Empty;
                retval.temperatureFahrenheit = _json.main.temp.ToString();
                retval.time = _json.timezone.ToString();
                retval.visibility = _json.visibility.ToString();
                retval.wind = string.Format("speed: {0}, deg: {1}", _json.wind.speed, _json.wind.deg);

                // retval = _json.data.Select(c => new CountryData() { Country = c.country, Cities = c.cities }).ToList();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMessage = ex.ToString();
            }
            return retval;
        }
        public string GetCelcius(string fahrenheit)
        {
            double celcius = (double.Parse(fahrenheit) - 32) * 5/9;
            return celcius.ToString();
        }
        public void Dispose()
        {

        }
    }
}
