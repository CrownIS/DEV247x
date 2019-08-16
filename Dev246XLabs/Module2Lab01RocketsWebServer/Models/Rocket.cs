using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module2Lab01RocketsWebServer.Models
{
    public class Rocket
    {
        public int ID { get; set; }
        public string Builder { get; set; }
        public string Target { get; set; }
        public double Speed { get; set; }
    }
}
