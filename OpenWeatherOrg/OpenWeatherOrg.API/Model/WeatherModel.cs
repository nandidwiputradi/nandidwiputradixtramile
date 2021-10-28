using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeatherOrg.API.Model
{
    public class WeatherModel
    {
        public string location { get; set; }
        public string time { get; set; }
        public string wind { get; set; }
        public string visibility { get; set; }
        public string skyConditions { get; set; }
        public string temperatureCelsius { get; set; }
        public string temperatureFahrenheit { get; set; }
        public string dewPoint { get; set; }
        public string relativeHumidity { get; set; }
        public string pressure { get; set; }
    }
}
