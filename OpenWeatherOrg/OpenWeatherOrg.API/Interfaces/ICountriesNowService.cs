using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeatherOrg.API.Interfaces
{
    public interface ICountriesNowService : IDisposable
    {
        List<string> GetCountryList();
        List<string> GetCityList(string _country);
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
