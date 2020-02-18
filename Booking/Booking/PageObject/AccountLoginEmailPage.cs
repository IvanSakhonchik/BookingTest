using OpenQA.Selenium;

namespace Booking
{
    public class AccountLoginEmailPage : PageObject
    {
        public IWebElement Email { get; set; }
        public AccountLoginEmailPage(IWebDriver driver) : base(driver)
        {
            Email = GetWebElement(By.Id("username"));
        }
    }
}
