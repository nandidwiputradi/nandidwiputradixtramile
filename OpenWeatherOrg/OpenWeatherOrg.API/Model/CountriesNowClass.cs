using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeatherOrg.API.Model
{
    public class CountriesNowClass
    {
        public bool error { get; set; }
        public string msg { get; set; }
        public List<Datum> data { get; set; }
    }
    public class Datum
    {
        public string country { get; set; }
        public List<string> cities { get; set; }
    }
}
