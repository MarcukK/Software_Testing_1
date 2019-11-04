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
        public static int timeoutInSeconds = 30;
        private IWebDriver DriverBookingWithoutDestination;
        private IWebDriver DriverOneWayReservationToDepartureCity;
        private IWebDriver DriverTwoWayReservationToDepartureCity;
        public string WebsiteURL;
        public string InitialURL;
        Random rand = new Random();

        [Obsolete]
        private static ReadOnlyCollection<IWebElement> WaitForElement(IWebDriver webDriver, By by)
        {
            return (new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds))
                .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by)));
        }

        public DefaultWait<IWebDriver> GetFluentWait(IWebDriver driver)
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
            WebsiteURL = "https://biletyplus.by/";
        }

        [Test, Description("Test is not complete")]
        public void BookingWithoutDate()
        {
            DriverBookingWithoutDestination = new ChromeDriver();

            DriverBookingWithoutDestination.Navigate().GoToUrl(WebsiteURL);

            DefaultWait<IWebDriver> fluentWait = GetFluentWait(DriverBookingWithoutDestination);

            IWebElement SubmitBookingButton = fluentWait.Until(x => x.FindElement(By.XPath("//div[1]/section[4]/div/div/form/div[4]/button")));
            SubmitBookingButton.Click();

            IWebElement TestWebSiteResult = fluentWait.Until(x => x.FindElement(By.XPath("//div[1]/section[4]/div/div/form/div[2]/div[3]/div/div[1]/span")));
            Assert.IsTrue(TestWebSiteResult != null, "Error in BookingWithoutWay");

        }

        [Test, Description("Test is not complete")]
        public void BookingWithoutDestination()
        {
            DriverBookingWithoutDestination = new ChromeDriver();

            DriverBookingWithoutDestination.Navigate().GoToUrl(WebsiteURL);

            DefaultWait<IWebDriver> fluentWait = GetFluentWait(DriverBookingWithoutDestination);

            IWebElement SelectFromDateElement = DriverBookingWithoutDestination.FindElement(By.XPath("//div[1]/section[4]/div/div/form/div[2]/div[3]/div/input[1]"));
            SelectFromDateElement.Click();
            SelectFromDateElement = DriverBookingWithoutDestination.FindElement(By.XPath("//div[14]/div[2]/a[2]"));
            SelectFromDateElement.Click();
            SelectFromDateElement = DriverBookingWithoutDestination.FindElement(By.XPath("//div[14]/table/tbody/tr[1]/td[7]/a"));
            SelectFromDateElement.Click();
            while (SelectFromDateElement.Displayed) ;

            IWebElement SubmitBookingButton = fluentWait.Until(x => x.FindElement(By.XPath("//div[1]/section[4]/div/div/form/div[4]/button")));
            SubmitBookingButton.Click();

            IWebElement TestWebSiteResult = fluentWait.Until(x => x.FindElement(By.XPath("//div[1]/section[4]/div/div/form/div[2]/div[3]/div/div[1]/span")));
            Assert.IsTrue(TestWebSiteResult != null, "Error in BookingWithoutDestination");

        }

        [Test, Description("Test is not complete")]
        public void OneWayReservationToDepartureCity()
        {
            DriverOneWayReservationToDepartureCity = new ChromeDriver();

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

            IWebElement TestWebSiteResult = fluentWait.Until(x => x.FindElement(By.CssSelector(".error-label.tabbed")));
            Assert.IsTrue(TestWebSiteResult != null, "Error in OneWayReservationToDepartureCity");
        }

        [Test, Description("Test is not complete")]
        public void TwoWayReservationToDepartureCity()
        {
            DriverTwoWayReservationToDepartureCity = new ChromeDriver();

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

            IWebElement TestWebSiteResult = fluentWait.Until(x => x.FindElement(By.CssSelector(".error-label.tabbed")));
            Assert.IsTrue(TestWebSiteResult != null, "Error in AirortChoice");
        }

        [TearDown]
        public void TearDownTest()
        {
            if (DriverBookingWithoutDestination != null)
                DriverBookingWithoutDestination.Quit();
            if (DriverOneWayReservationToDepartureCity != null)
                DriverOneWayReservationToDepartureCity.Quit();
            if (DriverTwoWayReservationToDepartureCity != null)
                DriverTwoWayReservationToDepartureCity.Quit();


            
        }
    }
}
