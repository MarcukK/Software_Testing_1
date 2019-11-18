using System;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace PageObject
{

    [TestFixture]
    public class Tests
    {
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
                Logger.Log.Info("Start of method");

                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(WebsiteURL);
                BookingWithoutDestination bookingWithoutDestination = new BookingWithoutDestination(driver);
                FlightData testData = FlightDataCreator.FlightDataFrom();

                bookingWithoutDestination
                    .FillFields(testData)
                    .SelectFromDateAsFirstDayNextMonth()
                    .Submit();

                Logger.Log.Info("End of method");

                Assert.IsTrue(bookingWithoutDestination.CheckErrorLabel(), "Error in BookingWithoutDestination");
            }

            catch (Exception ex)
            {
                Logger.Log.Error(ex);
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
            //Logger.SetLoggerName("TwoWayReservationToDepartureCity");
            try
            {
                Logger.Log.Info("Start of method");
                
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(WebsiteURL);

                Logger.Log.Info("Driver navigated");

                TwoWayReservationToDepartureCityPage twoWayReservationToDepartureCityPage = new TwoWayReservationToDepartureCityPage(driver);
                FlightData testData = FlightDataCreator.FlightDataFromAndTo();
                testData.setAirportTo(testData.getAirportFrom());


                twoWayReservationToDepartureCityPage
                    .FillFields(testData)
                    .SelectFromDateAsFirstDayNextMonth()
                    .SelectDateTo()
                    .Submit();
                //int fs = 1, fs2 = 0; // string for explicit error
                //int fs3 = fs / fs2;

                Logger.Log.Info("End of method");
                Assert.IsTrue(twoWayReservationToDepartureCityPage.CheckErrorLabel(), "TwoWayReservationToDepartureCity");

            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
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
