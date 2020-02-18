using OpenQA.Selenium;

namespace Booking
{
    public class AirPassagePage : PageObject
    {
        public IWebElement Title { get; set; }
        public AirPassagePage(IWebDriver driver) : base(driver)
        {
            Title = GetWebElement(By.XPath("//button[contains(@class,'searchButton')]"));
        }
    }
}
