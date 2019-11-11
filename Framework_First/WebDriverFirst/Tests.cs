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
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using PageObject;

namespace PageObject
{

    [TestFixture]
    public class Tests
    {
        private static int timeoutInSeconds = 30;
        private IWebDriver driver;
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
            Logger.InitLogger();
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(WebsiteURL);
                BookingWithoutDestination bookingWithoutDestination = new BookingWithoutDestination(driver);
                FlightData testData = FlightDataCreator.FlightDataFrom();

                bookingWithoutDestination
                    .FillFields(testData)
                    .SelectFromDateAsFirstDayNextMonth()
                    .Submit();

                Assert.IsTrue(bookingWithoutDestination.CheckErrorLabel(), "Error in BookingWithoutDestination");
            }

            catch (Exception ex)
            {
                var screenshot = driver.TakeScreenshot();
                var filePath = ".//" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }

        [Test, Description("Test is not complete")]
        public void TwoWayReservationToDepartureCity()
        {
            Logger.InitLogger();
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(WebsiteURL);
                TwoWayReservationToDepartureCityPage twoWayReservationToDepartureCityPage = new TwoWayReservationToDepartureCityPage(driver);
                FlightData testData = FlightDataCreator.FlightDataFromAndTo();
                testData.setAirportTo(testData.getAirportFrom());


                twoWayReservationToDepartureCityPage
                    .FillFields(testData)
                    .SelectFromDateAsFirstDayNextMonth()
                    .SelectDateTo()
                    .Submit();
                //int fs = 1, fs2 = 0;
                //int fs3 = fs / fs2;
                Assert.IsTrue(twoWayReservationToDepartureCityPage.CheckErrorLabel(), "TwoWayReservationToDepartureCity");

            }
            catch (Exception ex)
            {
                var screenshot = driver.TakeScreenshot();
                var filePath = ".//" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }

        [TearDown]
        public void TearDownTest()
        {
            if (driver != null)
                driver.Quit();

        }
    }
}
