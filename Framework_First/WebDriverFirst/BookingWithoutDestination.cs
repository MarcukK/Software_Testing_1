using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    class BookingWithoutDestination : Page
    {

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Укажите город назначения')]")]
        private readonly IWebElement IndicateTheCityOfDestinationErrorLabel;

        [Obsolete]
        public BookingWithoutDestination(IWebDriver driver) : base(driver) { }

        public new BookingWithoutDestination FillFields(FlightData flightData)
        {
            return (BookingWithoutDestination)base.FillFields(flightData);
        }

        public new BookingWithoutDestination SelectFromDateAsFirstDayNextMonth()
        {
            return (BookingWithoutDestination)base.SelectFromDateAsFirstDayNextMonth();
        }

        public new BookingWithoutDestination Submit()
        {
            return (BookingWithoutDestination)base.Submit();
        }

        public bool CheckErrorLabel()
        {
            Logger.Log.Info("Check error label");
            IndicateTheCityOfDestinationErrorLabel.Click();
            return true;
        }
    }
}
