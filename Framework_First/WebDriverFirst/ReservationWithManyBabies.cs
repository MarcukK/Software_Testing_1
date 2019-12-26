using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    class ReservationWithManyBabies : Page
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='flight_data_info']/span[2]/span[1]")]
        protected readonly IWebElement PassengersElement;

        [FindsBy(How = How.XPath, Using = "//*[@id='counter_amount-baby']/div[1]/button[2]")]
        protected readonly IWebElement IncreaseBabiesElement;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Билеты не найдены')]")]
        protected IWebElement NoTicketsElement;

        public ReservationWithManyBabies(IWebDriver driver) : base(driver) { }

        public new ReservationWithManyBabies FillFields(FlightData flightData)
        {
            return (ReservationWithManyBabies)base.FillFields(flightData);
        }

        public new ReservationWithManyBabies SelectFromDateAsFirstDayNextMonth()
        {
            return (ReservationWithManyBabies)base.SelectFromDateAsFirstDayNextMonth();
        }

        public new ReservationWithManyBabies SelectDateTo()
        {
            return (ReservationWithManyBabies)base.SelectDateTo();
        }

        public ReservationWithManyBabies IncreaseCountOfBabies()
        {
            Logger.Log.Info("Increasing count of babies");
            PassengersElement.Click();
            IncreaseBabiesElement.Click();
            IncreaseBabiesElement.Click();
            PassengersElement.Click();
            return this;
        }

        public new ReservationWithManyBabies SwitchToNewWindow()
        {
            return (ReservationWithManyBabies)base.SwitchToNewWindow();
        }

        public new ReservationWithManyBabies WaitForResults()
        {
            Logger.Log.Info("Wait for results");
            fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Проверяем  ')]")).Displayed);
            IWebElement WaitingLabel = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Проверяем  ')]")));
            while (WaitingLabel.Displayed) ;
            return this;
            
        }

        public bool CheckResult()
        {
            Logger.Log.Info("Check label");
            fluentWait.Until(x => x.FindElement(By.XPath("//p[contains(text(),'Билеты не найдены')]")).Displayed);
            NoTicketsElement = fluentWait.Until(x => x.FindElement(By.XPath("//p[contains(text(),'Билеты не найдены')]")));
            NoTicketsElement.Click();
            return true;
        }
    }
}
