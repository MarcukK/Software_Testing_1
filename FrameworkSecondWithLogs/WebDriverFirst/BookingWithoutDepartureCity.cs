using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    class BookingWithoutDepartureCity : Page
    {

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Укажите город вылета')]")]
        private readonly IWebElement IndicateTheCityOfDepartureErrorLabel;

        [Obsolete]
        public BookingWithoutDepartureCity(IWebDriver driver) : base(driver) { }

        public new BookingWithoutDepartureCity FillFields(FlightData flightData)
        {
            return (BookingWithoutDepartureCity)base.FillFields(flightData);
        }

        public new BookingWithoutDepartureCity SelectFromDateAsFirstDayNextMonth()
        {
            return (BookingWithoutDepartureCity)base.SelectFromDateAsFirstDayNextMonth();
        }

        public new BookingWithoutDepartureCity Submit()
        {
            return (BookingWithoutDepartureCity)base.Submit();
        }

        public bool CheckErrorLabel()
        {
            Logger.Log.Info("Check error label");
            IndicateTheCityOfDepartureErrorLabel.Click();
            return true;
        }
    }
}
