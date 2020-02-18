using OpenQA.Selenium;

namespace Booking
{
    public class LondonFilterPage : PageObject
    {
        public IWebElement Title { get; set; }
        public LondonFilterPage(IWebDriver driver) : base(driver)
        {
            Title = GetWebElement(By.XPath("//h2[contains(text(),'Лондон:')]"));
        }
    }
}
