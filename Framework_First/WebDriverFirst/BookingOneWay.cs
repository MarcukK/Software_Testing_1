using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    class BookingOneWay : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[text()='Самый быстрый']/..//span[1]")]
        private IWebElement TheFastestWaySpan;

        public BookingOneWay(IWebDriver driver) : base(driver) { }

        public new BookingOneWay FillFields(FlightData flightData)
        {
            return (BookingOneWay)base.FillFields(flightData);
        }

        public new BookingOneWay SelectFromDateAsFirstDayNextMonth()
        {
            return (BookingOneWay)base.SelectFromDateAsFirstDayNextMonth();
        }

        public new BookingOneWay SelectDateTo()
        {
            return (BookingOneWay)base.SelectDateTo();
        }

        public new BookingOneWay Submit()
        {
            return (BookingOneWay)base.Submit();
        }

        public new BookingOneWay SwitchToNewWindow()
        {
            return (BookingOneWay)base.SwitchToNewWindow();
        }

        public new BookingOneWay WaitForResults()
        {
            return (BookingOneWay)base.WaitForResults();
        }

        public bool Check()
        {
            Logger.Log.Info("Check label");

            fluentWait.Until(x => x.FindElement(By.XPath("//div[text()='Самый быстрый']/..//span[1]")).Displayed);
            TheFastestWaySpan = fluentWait.Until(x => x.FindElement(By.XPath("//div[text()='Самый быстрый']/..//span[1]")));

            TheFastestWaySpan.Click();
            return true;
        }
    }
}
