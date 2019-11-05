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

namespace WebDriverFirst
{

    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private static int timeoutInSeconds = 30;
        private IWebDriver DriverBookingWithoutDate;
        private IWebDriver DriverBookingWithoutDestination;
        private IWebDriver DriverOneWayReservationToDepartureCity;
        private IWebDriver DriverTwoWayReservationToDepartureCity;
        private string WebsiteURL;
        private string InitialURL;
        Random rand = new Random();

        [Obsolete]
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

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            WebsiteURL = "https://biletyplus.by/";
        }

        [Test, Description("Test is not complete")]
        public void BookingWithoutDate()
        {
            DriverBookingWithoutDate = driver;

            DriverBookingWithoutDate.Navigate().GoToUrl(WebsiteURL);

            DefaultWait<IWebDriver> fluentWait = GetFluentWait(DriverBookingWithoutDate);

            IWebElement AirportInputFieldFrom = DriverBookingWithoutDate.FindElement(By.CssSelector(".sf-input.location1.ui-autocomplete-input"));
            AirportInputFieldFrom.SendKeys("Минск");

            IWebElement AirportInputFieldTo = DriverBookingWithoutDate.FindElement(By.CssSelector(".sf-input.location2.ui-autocomplete-input"));
            AirportInputFieldTo.SendKeys("Париж");

            IWebElement SubmitBookingButton = fluentWait.Until(x => x.FindElement(By.CssSelector(".search_button.button_orange.button_middle")));
            SubmitBookingButton.Click();

            IWebElement TestWebSiteResult = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Укажите дату')]")));
            Assert.IsNotNull(TestWebSiteResult, "Error in BookingWithoutWay");

        }

        [Test, Description("Test is not complete")]
        public void BookingWithoutDestination()
        {
            DriverBookingWithoutDestination = driver;

            DriverBookingWithoutDestination.Navigate().GoToUrl(WebsiteURL);

            DefaultWait<IWebDriver> fluentWait = GetFluentWait(DriverBookingWithoutDestination);

            IWebElement AirportInputFieldFrom = DriverBookingWithoutDestination.FindElement(By.CssSelector(".sf-input.location1.ui-autocomplete-input"));
            AirportInputFieldFrom.SendKeys("Минск");

            IWebElement SelectFromDateElement = DriverBookingWithoutDestination.FindElement(By.CssSelector(".sf-input.date-text.date1text.hasDatepicker"));
            SelectFromDateElement.Click();
            SelectFromDateElement = DriverBookingWithoutDestination.FindElement(By.CssSelector(".ui-datepicker-next.ui-corner-all"));
            SelectFromDateElement.Click();
            SelectFromDateElement = DriverBookingWithoutDestination.FindElement(By.CssSelector(".ui-datepicker-week-end.date_2019-12-01"));
            SelectFromDateElement.Click();
            while (SelectFromDateElement.Displayed) ;

            IWebElement SubmitBookingButton = fluentWait.Until(x => x.FindElement(By.CssSelector(".search_button.button_orange.button_middle")));
            SubmitBookingButton.Click();

            IWebElement TestWebSiteResult = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Укажите город назначения')]")));
            Assert.IsNotNull(TestWebSiteResult, "Error in BookingWithoutDestination");

        }

        [Test, Description("Test is not complete")]
        public void OneWayReservationToDepartureCity()
        {
            DriverOneWayReservationToDepartureCity = driver;

            DriverOneWayReservationToDepartureCity.Navigate().GoToUrl(WebsiteURL);

            DefaultWait<IWebDriver> fluentWait = GetFluentWait(DriverOneWayReservationToDepartureCity);

            IWebElement AirportInputFieldFrom = DriverOneWayReservationToDepartureCity.FindElement(By.CssSelector(".sf-input.location1.ui-autocomplete-input"));
            AirportInputFieldFrom.SendKeys("Минск");

            IWebElement AirportInputFieldTo = DriverOneWayReservationToDepartureCity.FindElement(By.CssSelector(".sf-input.location2.ui-autocomplete-input"));
            AirportInputFieldTo.SendKeys("Минск");

            IWebElement SelectFromDateElement = DriverOneWayReservationToDepartureCity.FindElement(By.CssSelector(".sf-input.date-text.date1text.hasDatepicker"));
            SelectFromDateElement.Click();
            SelectFromDateElement = DriverOneWayReservationToDepartureCity.FindElement(By.CssSelector(".ui-datepicker-next.ui-corner-all"));
            SelectFromDateElement.Click();
            SelectFromDateElement = DriverOneWayReservationToDepartureCity.FindElement(By.CssSelector(".ui-datepicker-week-end.date_2019-12-01"));
            SelectFromDateElement.Click();
            while (SelectFromDateElement.Displayed) ;

            IWebElement SubmitBookingButton = fluentWait.Until(x => x.FindElement(By.CssSelector(".search_button.button_orange.button_middle")));
            SubmitBookingButton.Click();

            IWebElement TestWebSiteResult = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Не может совпадать с пунктом отправления')]")));
            Assert.IsNotNull(TestWebSiteResult, "Error in OneWayReservationToDepartureCity");
        }

        [Test, Description("Test is not complete")]
        public void TwoWayReservationToDepartureCity()
        {
            DriverTwoWayReservationToDepartureCity = driver;

            DriverTwoWayReservationToDepartureCity.Navigate().GoToUrl(WebsiteURL);

            DefaultWait<IWebDriver> fluentWait = GetFluentWait(DriverTwoWayReservationToDepartureCity);

            IWebElement AirportInputFieldFrom = DriverTwoWayReservationToDepartureCity.FindElement(By.CssSelector(".sf-input.location1.ui-autocomplete-input"));
            AirportInputFieldFrom.SendKeys("Минск");

            IWebElement AirportInputFieldTo = DriverTwoWayReservationToDepartureCity.FindElement(By.CssSelector(".sf-input.location2.ui-autocomplete-input"));
            AirportInputFieldTo.SendKeys("Минск");

            IWebElement SelectFromDateElement = DriverTwoWayReservationToDepartureCity.FindElement(By.CssSelector(".sf-input.date-text.date1text.hasDatepicker"));
            SelectFromDateElement.Click();
            fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='ui-datepicker-div']/div[2]/a[2]")));
            IWebElement SelectFromDateElementDate = DriverTwoWayReservationToDepartureCity.FindElement(By.XPath("//*[@id='ui-datepicker-div']/div[2]/a[2]"));
            SelectFromDateElementDate.Click();
            SelectFromDateElementDate = DriverTwoWayReservationToDepartureCity.FindElement(By.CssSelector(".ui-datepicker-week-end.date_2019-12-01"));
            SelectFromDateElementDate.Click();
            while (SelectFromDateElementDate.Displayed) ;

            fluentWait.Until(x => x.FindElement(By.CssSelector(".generator_cell.search-input-area.date_cell_to.date_field.search_to_time")));
            IWebElement SelectToDateElement = DriverTwoWayReservationToDepartureCity.FindElement(By.CssSelector(".generator_cell.search-input-area.date_cell_to.date_field.search_to_time"));
            SelectToDateElement.Click();
            fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='ui-datepicker-div']/div[2]/a[2]")));
            IWebElement SelectToDateElementDate = DriverTwoWayReservationToDepartureCity.FindElement(By.CssSelector(".date_2019-12-02"));
            SelectToDateElementDate.Click();
            while (SelectToDateElementDate.Displayed) ;

            IWebElement SubmitBookingButton = fluentWait.Until(x => x.FindElement(By.CssSelector(".search_button.button_orange.button_middle")));
            SubmitBookingButton.Click();

            IWebElement TestWebSiteResult = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Не может совпадать с пунктом отправления')]")));
            Assert.IsNotNull(TestWebSiteResult, "TwoWayReservationToDepartureCity");
        }

        [TearDown]
        public void TearDownTest()
        {
            if (driver != null)
                driver.Quit();
            
        }
    }
}
