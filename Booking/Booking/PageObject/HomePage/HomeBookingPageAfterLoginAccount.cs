using OpenQA.Selenium;

namespace Booking
{
    public class HomeBookingPageAfterLoginAccount : PageObject
    {
        public IWebElement User { get; set; }
        public HomeBookingPageAfterLoginAccount(IWebDriver driver) : base(driver)
        {
            User = GetWebElement(By.XPath("//span[contains(text(),'Иван')]"));
        }
    }
}
