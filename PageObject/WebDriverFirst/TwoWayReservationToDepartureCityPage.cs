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
    class BookingPage
    {
        protected static String URL_MATCH = "https://biletyplus.by/";

        protected DefaultWait<IWebDriver> fluentWait;
        protected IWebDriver driver;
        protected static int timeoutInSeconds = 30;
        protected readonly IWebElement AirportInputFieldFrom;
        protected readonly IWebElement AirportInputFieldTo;
        protected readonly IWebElement SelectFromDateElement;
        protected readonly IWebElement ChangeMonthElement;
        protected readonly IWebElement SelectFromDateElementDate;
        protected readonly IWebElement SelectToDateElement;
        protected readonly IWebElement SelectToDateElementDate;
        protected readonly IWebElement SubmitBookingButton;

        private static ReadOnlyCollection<IWebElement> WaitForElement(IWebDriver webDriver, By by)
        {
            return (new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds))
                .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by)));
        }

        public static DefaultWait<IWebDriver> GetFluentWait(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(50);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait;
        }
    }

    class BookingWithoutDestination : BookingPage
    {
        [FindsBy(How = How.CssSelector, Using = ".sf-input.location1.ui-autocomplete-input")]
        private readonly IWebElement AirportInputFieldFrom;

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
        public BookingWithoutDestination(IWebDriver driver)
        {
            // проверить, что вы находитесь на верной странице
            if (!driver.Url.Contains(URL_MATCH))
            {
                throw new Exception(
                    "This is not the page you are expected"
                    );
            }
            fluentWait = GetFluentWait(driver);
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public BookingWithoutDestination FillFieldFrom(string text)
        {
            AirportInputFieldFrom.SendKeys(text);
            return this;
        }

        public BookingWithoutDestination SelectDateFrom()
        {
            SelectFromDateElement.Click();
            ChangeMonthElement.Click();
            SelectFromDateElementDate.Click();
            while (SelectFromDateElementDate.Displayed) ;
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

    class TwoWayReservationToDepartureCityPage : BookingPage
    {
        private static String URL_MATCH = "https://biletyplus.by/";

        private DefaultWait<IWebDriver> fluentWait;
        private IWebDriver driver;
        private static int timeoutInSeconds = 30;

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

        [Obsolete]
        public TwoWayReservationToDepartureCityPage(IWebDriver driver)
        {
            // проверить, что вы находитесь на верной странице
            if (!driver.Url.Contains(URL_MATCH))
            {
                throw new Exception(
                    "This is not the page you are expected"
                    );
            }
            fluentWait = GetFluentWait(driver);
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public TwoWayReservationToDepartureCityPage FillFieldFrom(string text)
        {
            AirportInputFieldFrom.SendKeys(text);
            return this;
        }

        public TwoWayReservationToDepartureCityPage FillFieldTo(string text)
        {
            AirportInputFieldTo.SendKeys(text);
            return this;
        }

        public TwoWayReservationToDepartureCityPage SelectDateFrom()
        {
            SelectFromDateElement.Click();
            ChangeMonthElement.Click();
            SelectFromDateElementDate.Click();
            while (SelectFromDateElementDate.Displayed) ;
            return this;
        }

        public TwoWayReservationToDepartureCityPage SelectDateTo()
        {
            SelectToDateElement.Click();
            SelectToDateElementDate.Click();
            return this;
        }

        public TwoWayReservationToDepartureCityPage Submit()
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
