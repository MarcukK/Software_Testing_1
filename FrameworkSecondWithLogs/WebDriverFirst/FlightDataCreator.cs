using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    class FlightDataCreator
    {

        public static string AIRPORT_FROM = StringUtils.DataStringAirportFrom;
        public static string AIRPORT_TO = StringUtils.DataStringAirportTo;

        public static FlightData FlightDataFromAndTo()
        {
            return new FlightData(AIRPORT_FROM, AIRPORT_TO);
        }
        public static FlightData FlightDataFrom()
        {
            return new FlightData(AIRPORT_FROM, " ");
        }
        public static FlightData FlightDataTo()
        {
            return new FlightData(" ", AIRPORT_TO);
        }
        public static FlightData FlightDataEmpty()
        {
            return new FlightData(" ", " ");
        }

    }
}
