using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace PageObject
{
    class PricesCheck : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[text()='Самый быстрый']/..//span[1]")]
        private IWebElement TheFastestWaySpan;

        [FindsBy(How = How.XPath, Using = "//div[text()='Самый дешевый']/..//span[1]")]
        private IWebElement TheCheapestWaySpan;

        public PricesCheck(IWebDriver driver) : base(driver) { }

        public new PricesCheck FillFields(FlightData flightData)
        {
            return (PricesCheck)base.FillFields(flightData);
        }

        public new PricesCheck SelectFromDateAsFirstDayNextMonth()
        {
            return (PricesCheck)base.SelectFromDateAsFirstDayNextMonth();
        }

        public new PricesCheck SelectDateTo()
        {
            return (PricesCheck)base.SelectDateTo();
        }

        public new PricesCheck Submit()
        {
            return (PricesCheck)base.Submit();
        }

        public new PricesCheck SwitchToNewWindow()
        {
            return (PricesCheck)base.SwitchToNewWindow();
        }

        public new PricesCheck WaitForResults()
        {
            return (PricesCheck)base.WaitForResults();
        }

        public bool CheckPrices()
        {
            Logger.Log.Info("Check label");
            fluentWait.Until(x => x.FindElement(By.XPath("//div[text()='Самый быстрый']/..//span[1]")).Displayed);
            TheFastestWaySpan = fluentWait.Until(x => x.FindElement(By.XPath("//div[text()='Самый быстрый']/..//span[1]")));
            return Convert.ToDouble(TheFastestWaySpan.Text) >= Convert.ToDouble(TheCheapestWaySpan.Text);
        }
    }
}
