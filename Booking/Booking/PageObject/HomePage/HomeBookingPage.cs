using OpenQA.Selenium;

namespace Booking
{
    public class HomeBookingPage : PageObject
    {
        public IWebElement AirPassage { get; set; }
        public IWebElement Language { get; set; }
        public IWebElement LoginToAccount { get; set; }

        public IWebElement City { get; set; }
        public IWebElement Date { get; set; }
        public IWebElement Peoples { get; set; }
        public IWebElement Checker { get; set; }

        public HomeBookingPage(IWebDriver driver): base(driver)
        {
            AirPassage = GetWebElement(By.XPath("//span[contains(text(),'Авиабилеты')]"));
            Language = GetWebElement(By.XPath("//a/img[@alt='На русском']"));
            LoginToAccount = GetWebElement(By.XPath("//span[contains(text(),'Войти')]"));

            City = GetWebElement(By.Id("ss"));
            Date = GetWebElement(By.XPath("//span[contains(@class,'calendar-restructure-sb')]"));
            Peoples = GetWebElement(By.XPath("//span[contains(text(),'взрослых')]"));
            Checker = GetWebElement(By.XPath("//span[contains(text(),'Проверить')]"));

        }
    }
}
