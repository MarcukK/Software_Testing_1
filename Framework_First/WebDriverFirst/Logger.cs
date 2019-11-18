using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace PageObject
{
    public static class Logger
    {
        private static ILog log = LogManager.GetLogger("LOGGER");


        public static ILog Log
        {
            get { return log; }
        }
        public static void SetLoggerName(string value)
        {
            log = LogManager.GetLogger(value);
        }


        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
