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

namespace PageObject
{

    [TestFixture]
    public class Tests
    {
        private static int timeoutInSeconds = 30;
        private IWebDriver DriverBookingWithoutDestination;
        private IWebDriver DriverTwoWayReservationToDepartureCity;
        private string WebsiteURL;
        Random rand = new Random();


        [SetUp]
        public void SetupTest()
        {
            WebsiteURL = "https://biletyplus.by/";
        }

        [Test, Description("Test is not complete")]
        public void BookingWithoutDestination()
        {
            DriverBookingWithoutDestination = new ChromeDriver();
            DriverBookingWithoutDestination.Navigate().GoToUrl(WebsiteURL);

            BookingWithoutDestination bookingWithoutDestination = new BookingWithoutDestination(DriverBookingWithoutDestination);

            bookingWithoutDestination
                .FillFieldFrom("Минск")
                .SelectDateFrom()
                .Submit();

            Assert.IsTrue(bookingWithoutDestination.CheckErrorLabel(), "Error in BookingWithoutDestination");

        }

        [Test, Description("Test is not complete")]
        public void TwoWayReservationToDepartureCity()
        {
            DriverTwoWayReservationToDepartureCity = new ChromeDriver();
            DriverTwoWayReservationToDepartureCity.Navigate().GoToUrl(WebsiteURL);

            TwoWayReservationToDepartureCityPage twoWayReservationToDepartureCityPage = new TwoWayReservationToDepartureCityPage(DriverTwoWayReservationToDepartureCity);

            twoWayReservationToDepartureCityPage
                .FillFieldFrom("Минск")
                .FillFieldTo("Минск")
                .SelectDateFrom()
                .SelectDateTo()
                .Submit();

            Assert.IsTrue(twoWayReservationToDepartureCityPage.CheckErrorLabel(), "TwoWayReservationToDepartureCity");
        }

        [TearDown]
        public void TearDownTest()
        {
            if (DriverBookingWithoutDestination != null)
                DriverBookingWithoutDestination.Quit();
            if (DriverTwoWayReservationToDepartureCity != null)
                DriverTwoWayReservationToDepartureCity.Quit();
            
        }
    }
}
