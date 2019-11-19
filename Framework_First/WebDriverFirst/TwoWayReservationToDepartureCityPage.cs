using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageObject
{
    class TwoWayReservationToDepartureCityPage : Page
    {
        [FindsBy(How = How.CssSelector, Using = ".sf-input.location1.ui-autocomplete-input")]
        private readonly IWebElement AirportInputFieldFrom;

        [FindsBy(How = How.CssSelector, Using = ".sf-input.location2.ui-autocomplete-input")]
        private readonly IWebElement AirportInputFieldTo;

        [FindsBy(How = How.CssSelector, Using = ".sf-input.date-text.date1text.hasDatepicker")]
        private readonly IWebElement SelectFromDateElement;

        [FindsBy(How = How.XPath, Using = "//*[@id='ui-datepicker-div']/div[2]/a[2]")]
        private readonly IWebElement ChangeMonthElement;

        [FindsBy(How = How.CssSelector, Using = ".ui-datepicker-week-end.date_2019-12-01")]
        private readonly IWebElement SelectFromDateElementDate;

        [FindsBy(How = How.CssSelector, Using = ".generator_cell.search-input-area.date_cell_to.date_field.search_to_time")]
        private readonly IWebElement SelectToDateElement;

        [FindsBy(How = How.CssSelector, Using = ".date_2019-12-02")]
        private readonly IWebElement SelectToDateElementDate;


        [FindsBy(How = How.CssSelector, Using = ".search_button.button_orange.button_middle")]
        private readonly IWebElement SubmitBookingButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Укажите город назначения')]")]
        private readonly IWebElement ArrivalCannotCoincideWithDepartureErrorLabel;

        public TwoWayReservationToDepartureCityPage(IWebDriver driver) : base(driver) { }

        public TwoWayReservationToDepartureCityPage FillFields(FlightData flightData)
        {
            Logger.Log.Info(flightData);
            AirportInputFieldFrom.SendKeys(flightData.getAirportFrom());
            AirportInputFieldTo.SendKeys(flightData.getAirportTo());
            return this;
        }

        public TwoWayReservationToDepartureCityPage SelectFromDateAsFirstDayNextMonth()
        {
            Logger.Log.Info("Selecting from date next month");
            SelectFromDateElement.Click();
            ChangeMonthElement.Click();
            SelectFromDateElementDate.Click();
            while (SelectFromDateElementDate.Displayed) ;
            return this;
        }

        public TwoWayReservationToDepartureCityPage SelectDateTo()
        {
            Logger.Log.Info("Selecting date to");
            SelectToDateElement.Click();
            SelectToDateElementDate.Click();
            return this;
        }

        public TwoWayReservationToDepartureCityPage Submit()
        {
            Logger.Log.Info("Submit");
            SubmitBookingButton.Click();
            return this;
        }

        public bool CheckErrorLabel()
        {
            Logger.Log.Info("Check error label");
            return (ArrivalCannotCoincideWithDepartureErrorLabel != null);
        }
    }

}
