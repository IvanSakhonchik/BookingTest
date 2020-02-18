using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Booking
{
    public class PageObject
    {
        protected IWebDriver Driver { get; set; }

        public PageObject(IWebDriver driver)
        {
            Driver = driver;
        }
        public IWebElement GetWebElement(By elementLocator)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
        }
    }
}
