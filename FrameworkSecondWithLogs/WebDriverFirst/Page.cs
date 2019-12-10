using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageObject
{
    public class Page
    {
        protected static String URL_MATCH = "https://biletyplus.by/";

        protected DefaultWait<IWebDriver> fluentWait;
        protected IWebDriver driver;
        protected IWebElement CloseAddButton;
        protected static int timeoutInSeconds = 45;

        [FindsBy(How = How.CssSelector, Using = ".sf-input.location1.ui-autocomplete-input")]
        protected readonly IWebElement AirportInputFieldFrom;

        [FindsBy(How = How.CssSelector, Using = ".sf-input.location2.ui-autocomplete-input")]
        protected readonly IWebElement AirportInputFieldTo;

        [FindsBy(How = How.CssSelector, Using = ".sf-input.date-text.date1text.hasDatepicker")]
        protected readonly IWebElement SelectFromDateElement;

        [FindsBy(How = How.XPath, Using = "//*[@id='ui-datepicker-div']/div[2]/a[2]")]
        protected readonly IWebElement ChangeMonthElement;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'1')]")]
        protected readonly IWebElement SelectFromDateElementDate;

        [FindsBy(How = How.CssSelector, Using = ".generator_cell.search-input-area.date_cell_to.date_field.search_to_time")]
        protected readonly IWebElement SelectToDateElement;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'7')]")]
        protected readonly IWebElement SelectToDateElementDate;

        [FindsBy(How = How.CssSelector, Using = ".search_button.button_orange.button_middle")]
        protected readonly IWebElement SubmitBookingButton;

        [Obsolete]
        public Page(IWebDriver driver)
        {
            if (this.driver == null)
            {
                PageFactory.InitElements(driver, this);
            }
            fluentWait = GetFluentWait(driver);
            this.driver = driver;
        }

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

        public Page FillFields(FlightData flightData)
        {
            Logger.Log.Info(flightData);
            AirportInputFieldFrom.SendKeys(flightData.getAirportFrom());
            AirportInputFieldTo.SendKeys(flightData.getAirportTo());
            return this;
        }

        public Page SelectFromDateAsFirstDayNextMonth()
        {
            Logger.Log.Info("Selecting from date next month");
            SelectFromDateElement.Click();
            ChangeMonthElement.Click();
            SelectFromDateElementDate.Click();
            while (SelectFromDateElementDate.Displayed) ;
            return this;
        }

        public Page SelectDateTo()
        {
            Logger.Log.Info("Selecting date to");
            SelectToDateElement.Click();
            SelectToDateElementDate.Click();
            return this;
        }

        public Page Submit()
        {
            Logger.Log.Info("Submit");
            SubmitBookingButton.Click();
            return this;
        }

        public Page SwitchToNewWindow()
        {
            Logger.Log.Info("Switch to new window");
            while (driver.Url == URL_MATCH)
            {
                SubmitBookingButton.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
            }
            //CloseAddButton = fluentWait.Until(x => x.FindElement(By.CssSelector(".IM_overlay_close_button.needsclick>img")));
            //while (!CloseAddButton.Displayed) ;
            //CloseAddButton.Click();
            return this;
        }

        public Page WaitForResults()
        {
            Logger.Log.Info("Wait for results");
            fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='aside_func']/div[2]/span")).Displayed);
            IWebElement WaitingLabel = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='aside_func']/div[2]/span")));
            while (WaitingLabel.Displayed) ;
            CloseAddButton = fluentWait.Until(x => x.FindElement(By.CssSelector(".IM_overlay_close_button.needsclick>img")));
            if (CloseAddButton.Displayed)
                CloseAddButton.Click();
            return this;
        }

    }
}
