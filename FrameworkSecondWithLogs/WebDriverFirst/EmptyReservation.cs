using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    class EmptyReservation : Page
    {
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Укажите дату')]")]
        private readonly IWebElement MissingDateErrorLabel;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Укажите город назначения')]")]
        private readonly IWebElement IndicateTheCityOfDestinationErrorLabel;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Укажите город вылета')]")]
        private readonly IWebElement IndicateTheCityOfDepartureErrorLabel;

        [Obsolete]
        public EmptyReservation(IWebDriver driver) : base(driver) { }

        public new EmptyReservation Submit()
        {
            return (EmptyReservation)base.Submit();
        }

        public bool CheckErrorLabel()
        {
            Logger.Log.Info("Check error label");
            MissingDateErrorLabel.Click();
            IndicateTheCityOfDepartureErrorLabel.Click();
            IndicateTheCityOfDestinationErrorLabel.Click();
            return true;
        }
    }
}
