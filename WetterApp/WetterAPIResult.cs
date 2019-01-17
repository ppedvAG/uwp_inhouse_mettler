using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetterApp
{
    public class WetterAPIResult
    {
        public Weather[] weather { get; set; }   
        public Main main { get; set; }
    }

    public class Main
    {
        public int temp_min { get; set; }
        public int temp_max { get; set; }
    }

    public class Weather
    {
        public string description { get; set; }
        public string icon { get; set; }
        public string IconUrl => $"http://openweathermap.org/img/w/{icon}.png"; 
    }
}
