using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenWeatherOrg.API.Model;
using OpenWeatherOrg.API.Interfaces;
using Newtonsoft.Json;

namespace OpenWeatherOrg.API.Services
{
    public class CountriesNowService : ICountriesNowService
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        private List<CountryData> GetData()
        {
            List<CountryData> retval = new List<CountryData>();
            IsError = false;
            try
            {
                WebRequest request = WebRequest.Create("https://countriesnow.space/api/v0.1/countries/");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string dataReader = reader.ReadToEnd();

                var _json = JsonConvert.DeserializeObject<CountriesNowClass>(dataReader);

                reader.Close();
                dataStream.Close();
                response.Close();

                if (IsError = _json.error)
                {
                    ErrorMessage = _json.msg;
                    return retval;
                }

                retval = _json.data.Select(c => new CountryData() { Country = c.country, Cities = c.cities }).ToList();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMessage = ex.ToString();
            }

            return retval;
        }
        public List<string> GetCountryList()
        {
            return GetData().Select(c => c.Country).ToList();
        }

        public List<string> GetCityList(string _country)
        {
            return GetData().Where(c => c.Country == _country).FirstOrDefault().Cities;
        }

        public void Dispose()
        {

        }
    }
}
