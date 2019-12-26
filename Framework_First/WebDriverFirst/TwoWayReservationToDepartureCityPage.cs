using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    class TwoWayReservationToDepartureCityPage : Page
    {

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Не может совпадать с пунктом отправления')]")]
        private readonly IWebElement ArrivalCannotCoincideWithDepartureErrorLabel;

        public TwoWayReservationToDepartureCityPage(IWebDriver driver) : base(driver) { }

        public new TwoWayReservationToDepartureCityPage FillFields(FlightData flightData)
        {
            return (TwoWayReservationToDepartureCityPage)base.FillFields(flightData);
        }

        public new TwoWayReservationToDepartureCityPage SelectFromDateAsFirstDayNextMonth()
        {
            return (TwoWayReservationToDepartureCityPage)base.SelectFromDateAsFirstDayNextMonth();
        }

        public new TwoWayReservationToDepartureCityPage SelectDateTo()
        {
            return (TwoWayReservationToDepartureCityPage)base.SelectDateTo();
        }

        public new TwoWayReservationToDepartureCityPage Submit()
        {
            return (TwoWayReservationToDepartureCityPage)base.Submit();
        }

        public bool CheckErrorLabel()
        {
            Logger.Log.Info("Check error label");
            ArrivalCannotCoincideWithDepartureErrorLabel.Click();
            return true;
        }
    }

}
