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

        private void ErrorHandler(Exception ex)
        {
            Logger.Log.Error(ex);
            var screenshot = driver.TakeScreenshot();
            var filePath = ".//" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
            screenshot.SaveAsFile(filePath);
            throw ex;
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
                ErrorHandler(ex);
            }
        }

        [Test, Description("Test is not complete")]
        public void BookingWithoutDepartureCity()
        {
            Logger.InitLogger();
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(WebsiteURL);

                BookingWithoutDepartureCity bookingWithoutDepartureCity = new BookingWithoutDepartureCity(driver);
                FlightData testData = FlightDataCreator.FlightDataTo();

                bookingWithoutDepartureCity
                    .FillFields(testData)
                    .SelectFromDateAsFirstDayNextMonth()
                    .Submit();

                Assert.IsTrue(bookingWithoutDepartureCity.CheckErrorLabel(), "Error in BookingWithoutDepartureCity");
            }

            catch (Exception ex)
            {
                ErrorHandler(ex);
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
                Assert.IsTrue(twoWayReservationToDepartureCityPage.CheckErrorLabel(), "TwoWayReservationToDepartureCity");

            }
            catch (Exception ex)
            {
                ErrorHandler(ex);
            }
        }

        [Test, Description("Test is not complete")]
        public void OneWayReservationToDepartureCity()
        {
            Logger.InitLogger();
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(WebsiteURL);

                OneWayReservationToDepartureCityPage oneWayReservationToDepartureCityPage = new OneWayReservationToDepartureCityPage(driver);
                FlightData testData = FlightDataCreator.FlightDataFromAndTo();
                testData.setAirportTo(testData.getAirportFrom());

                oneWayReservationToDepartureCityPage
                    .FillFields(testData)
                    .SelectFromDateAsFirstDayNextMonth()
                    .SelectDateTo()
                    .Submit();
                Assert.IsTrue(oneWayReservationToDepartureCityPage.CheckErrorLabel(), "OneWayReservationToDepartureCity");

            }
            catch (Exception ex)
            {
                ErrorHandler(ex);
            }
        }

        [Test, Description("Test is not complete")]
        public void BookingWithoutDate()
        {
            Logger.InitLogger();
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(WebsiteURL);

                BookingWithoutDate bookingWithoutDate = new BookingWithoutDate(driver);
                FlightData testData = FlightDataCreator.FlightDataFromAndTo();

                bookingWithoutDate
                    .FillFields(testData)
                    .Submit();

                Assert.IsTrue(bookingWithoutDate.CheckErrorLabel(), "Error in BookingWithoutDate");
            }

            catch (Exception ex)
            {
                ErrorHandler(ex);
            }
        }

        [Test, Description("Test is not complete")]
        public void EmptyReservation()
        {
            Logger.InitLogger();
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(WebsiteURL);

                EmptyReservation emptyReservation = new EmptyReservation(driver);
                FlightData testData = FlightDataCreator.FlightDataEmpty();

                emptyReservation
                    .FillFields(testData)
                    .Submit();

                Assert.IsTrue(emptyReservation.CheckErrorLabel(), "Error in EmptyReservation");
            }

            catch (Exception ex)
            {
                ErrorHandler(ex);
            }
        }

        [Test, Description("Test is not complete")]
        public void BookingTwoWays()
        {
            Logger.InitLogger();
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(WebsiteURL);

                BookingTwoWays bookingTwoWays = new BookingTwoWays(driver);
                FlightData testData = FlightDataCreator.FlightDataFromAndTo();

                bookingTwoWays
                    .FillFields(testData)
                    .SelectFromDateAsFirstDayNextMonth()
                    .SelectDateTo()
                    .SwitchToNewWindow()
                    .WaitForResults();
                Assert.IsTrue(bookingTwoWays.CheckResults(), "BookingTwoWays");

            }
            catch (Exception ex)
            {
                ErrorHandler(ex);
            }
        }

        [Test, Description("Test is not complete")]
        public void BookingOneWay()
        {
            Logger.InitLogger();
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(WebsiteURL);

                BookingOneWay bookingOneWay = new BookingOneWay(driver);
                FlightData testData = FlightDataCreator.FlightDataFromAndTo();

                bookingOneWay
                    .FillFields(testData)
                    .SelectFromDateAsFirstDayNextMonth()
                    .SwitchToNewWindow()
                    .WaitForResults();
                Assert.IsTrue(bookingOneWay.Check(), "BookingOneWay");

            }
            catch (Exception ex)
            {
                ErrorHandler(ex);
            }
        }

        [Test, Description("Test is not complete")]
        public void PricesCheck()
        {
            Logger.InitLogger();
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(WebsiteURL);

                PricesCheck pricesCheck = new PricesCheck(driver);
                FlightData testData = FlightDataCreator.FlightDataFromAndTo();

                pricesCheck
                    .FillFields(testData)
                    .SelectFromDateAsFirstDayNextMonth()
                    .SwitchToNewWindow()
                    .WaitForResults();
                Assert.IsTrue(pricesCheck.CheckPrices(), "PricesCheck");

            }
            catch (Exception ex)
            {
                ErrorHandler(ex);
            }
        }

        [Test, Description("Test is not complete")]
        public void ReservationWithManyBabies()
        {
            Logger.InitLogger();
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(WebsiteURL);

                ReservationWithManyBabies reservationWithManyBabies = new ReservationWithManyBabies(driver);
                FlightData testData = FlightDataCreator.FlightDataFromAndTo();

                reservationWithManyBabies
                    .FillFields(testData)
                    .SelectFromDateAsFirstDayNextMonth()
                    .IncreaseCountOfBabies()
                    .SwitchToNewWindow()
                    .WaitForResults();
                Assert.IsTrue(reservationWithManyBabies.CheckResult(), "ReservationWithManyBabies");

            }
            catch (Exception ex)
            {
                ErrorHandler(ex);
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
