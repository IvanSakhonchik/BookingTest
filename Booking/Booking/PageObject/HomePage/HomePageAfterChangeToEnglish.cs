using OpenQA.Selenium;

namespace Booking
{
    public class HomePageAfterChangeToEnglish : PageObject
    {
        public IWebElement Language { get; set; }
        public HomePageAfterChangeToEnglish(IWebDriver driver) : base(driver)
        {
            Language = GetWebElement(By.XPath("//img[contains(@alt,'English (US)')]"));
        }
    }
}
