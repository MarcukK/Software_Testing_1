using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    class BookingWithoutDate : Page
    {

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Укажите дату')]")]
        private readonly IWebElement MissingDateErrorLabel;

        [Obsolete]
        public BookingWithoutDate(IWebDriver driver) : base(driver) { }

        public new BookingWithoutDate FillFields(FlightData flightData)
        {
            return (BookingWithoutDate)base.FillFields(flightData);
        }

        public new BookingWithoutDate Submit()
        {
            return (BookingWithoutDate)base.Submit();
        }

        public bool CheckErrorLabel()
        {
            Logger.Log.Info("Check error label");
            MissingDateErrorLabel.Click();
            return true;
        }
    }
}
