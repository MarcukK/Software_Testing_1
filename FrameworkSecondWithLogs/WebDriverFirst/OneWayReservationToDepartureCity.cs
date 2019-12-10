using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    class OneWayReservationToDepartureCityPage : Page
    {

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Не может совпадать с пунктом отправления')]")]
        private readonly IWebElement ArrivalCannotCoincideWithDepartureErrorLabel;

        public OneWayReservationToDepartureCityPage(IWebDriver driver) : base(driver) { }

        public new OneWayReservationToDepartureCityPage FillFields(FlightData flightData)
        {
            return (OneWayReservationToDepartureCityPage)base.FillFields(flightData);
        }

        public new OneWayReservationToDepartureCityPage SelectFromDateAsFirstDayNextMonth()
        {
            return (OneWayReservationToDepartureCityPage)base.SelectFromDateAsFirstDayNextMonth();
        }

        public new OneWayReservationToDepartureCityPage Submit()
        {
            return (OneWayReservationToDepartureCityPage)base.Submit();
        }

        public bool CheckErrorLabel()
        {
            Logger.Log.Info("Check error label");
            ArrivalCannotCoincideWithDepartureErrorLabel.Click();
            return true;
        }
    }

}
