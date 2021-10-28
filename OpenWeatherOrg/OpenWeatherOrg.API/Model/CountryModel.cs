using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeatherOrg.API.Model
{
    public class CountryModel
    {
        public List<CountryData> Countries { get; set; }
        public List<string> Cities { get; set; }
    }
    public class CountryData
    {
        public string Country { get; set; }
        public List<string> Cities { get; set; }
    }
}
