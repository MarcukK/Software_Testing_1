using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    class BookingTwoWays : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[text()='Самый быстрый']/..//span[1]")]
        private IWebElement TheFastestWaySpan;

        public BookingTwoWays(IWebDriver driver) : base(driver) { }

        public new BookingTwoWays FillFields(FlightData flightData)
        {
            return (BookingTwoWays)base.FillFields(flightData);
        }

        public new BookingTwoWays SelectFromDateAsFirstDayNextMonth()
        {
            return (BookingTwoWays)base.SelectFromDateAsFirstDayNextMonth();
        }

        public new BookingTwoWays SelectDateTo()
        {
            return (BookingTwoWays)base.SelectDateTo();
        }

        public new BookingTwoWays Submit()
        {
            return (BookingTwoWays)base.Submit();
        }

        public new BookingTwoWays SwitchToNewWindow()
        {
            return (BookingTwoWays)base.SwitchToNewWindow();
        }

        public new BookingTwoWays WaitForResults()
        {
            return (BookingTwoWays)base.WaitForResults();
        }
        
        public bool CheckResults()
        {
            Logger.Log.Info("Check label");
            fluentWait.Until(x => x.FindElement(By.XPath("//div[text()='Самый быстрый']/..//span[1]")).Displayed);
            TheFastestWaySpan = fluentWait.Until(x => x.FindElement(By.XPath("//div[text()='Самый быстрый']/..//span[1]")));
            TheFastestWaySpan.Click();
            return true;
        }
    }
}
