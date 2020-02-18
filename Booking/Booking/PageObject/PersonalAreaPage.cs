using OpenQA.Selenium;

namespace Booking
{
    public class PersonalAreaPage : PageObject
    {
        public IWebElement UserName { get; set; }
        public PersonalAreaPage(IWebDriver driver) : base(driver)
        {
            UserName = GetWebElement(By.XPath("//div[contains(text(),'Иван Иванович')]"));
        }
    }
}
