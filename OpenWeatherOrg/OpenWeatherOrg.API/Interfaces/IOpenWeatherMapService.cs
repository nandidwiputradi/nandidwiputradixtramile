using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenWeatherOrg.API.Model;

namespace OpenWeatherOrg.API.Interfaces
{
  public  interface IOpenWeatherMapService : IDisposable
    {
        WeatherModel GetData(string cityName);
        string GetCelcius(string fahrenheit);
        bool IsError { get; set; }
        string ErrorMessage { get; set; }
    }
}
