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
using OpenQA.Selenium.Support.UI;
using PageObject;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    class BookingWithoutDestination : Page
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

        [FindsBy(How = How.CssSelector, Using = ".search_button.button_orange.button_middle")]
        private readonly IWebElement SubmitBookingButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Не может совпадать с пунктом отправления')]")]
        private readonly IWebElement ArrivalCannotCoincideWithDepartureErrorLabel;

        [Obsolete]
        public BookingWithoutDestination(IWebDriver driver) : base(driver) { }

        public BookingWithoutDestination FillFields(FlightData flightData)
        {
            AirportInputFieldFrom.SendKeys(flightData.getAirportFrom());
            AirportInputFieldTo.SendKeys(flightData.getAirportTo());
            return this;
        }

        public BookingWithoutDestination SelectFromDateAsFirstDayNextMonth()
        {
            SelectFromDateElement.Click();
            ChangeMonthElement.Click();
            SelectFromDateElementDate.Click();
            while (SelectFromDateElementDate.Displayed);
            return this;
        }

        public BookingWithoutDestination Submit()
        {
            SubmitBookingButton.Click();
            return this;
        }

        public bool CheckErrorLabel()
        {
            return (ArrivalCannotCoincideWithDepartureErrorLabel != null);
        }
    }
}
