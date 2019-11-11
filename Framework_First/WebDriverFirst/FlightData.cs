using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public class FlightData
    {
        private string AirportFrom;
        private string AirportTo;

        public FlightData(string from, string to)
        {
            this.AirportFrom = from; 
            this.AirportTo = to;
        }

        public string getAirportFrom() { return AirportFrom; }

        public void setAirportFrom(string airportFrom) { this.AirportFrom = airportFrom; }

        public string getAirportTo() { return AirportTo; }

        public void setAirportTo(string airportTo) { this.AirportTo = airportTo; }

    }
}
