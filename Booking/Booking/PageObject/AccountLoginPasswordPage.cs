using OpenQA.Selenium;

namespace Booking
{
    public class AccountLoginPasswordPage : PageObject
    {
        public IWebElement Password { get; set; }
        public AccountLoginPasswordPage(IWebDriver driver) : base(driver)
        {
            Password = GetWebElement(By.Id("password"));
        }
    }
}
