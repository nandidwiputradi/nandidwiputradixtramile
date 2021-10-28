using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenWeatherOrg.API.Interfaces;
using OpenWeatherOrg.API.Services;
using OpenWeatherOrg.API.Model;

namespace OpenWeatherOrg.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private readonly ILogger<CountryController> _logger;
        private ICountriesNowService _countriesNowService;
        private IOpenWeatherMapService _openWeatherMapService;

        public CountryController(ILogger<CountryController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetCountryList")]
        public JsonResult GetCountryList()
        {
            List<string> retval = new List<string>();
            
            using (_countriesNowService = new CountriesNowService())
            {
                retval = _countriesNowService.GetCountryList();
            }

            return Json(retval);
        }
        [HttpGet("GetCityList")]
        public JsonResult GetCityList()
        {
            List<string> retval = new List<string>();
            string countryName = HttpContext.Request.Query["countryName"].ToString();
            using (_countriesNowService = new CountriesNowService())
            {
                retval = _countriesNowService.GetCityList(countryName);
            }

            return Json(retval);
        }
        [HttpGet("GetWeather")]
        public JsonResult GetWeather()
        {            
            string cityName = HttpContext.Request.Query["cityName"].ToString();
            WeatherModel model = new WeatherModel();

            using (_openWeatherMapService = new OpenWeatherMapService())
            {
                model = _openWeatherMapService.GetData(cityName);
                model.temperatureCelsius = _openWeatherMapService.GetCelcius(model.temperatureFahrenheit);
            }
            
            return Json(model);
        }
    }
}
