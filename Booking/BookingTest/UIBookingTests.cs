using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Booking;

namespace BookingTest
{
    public class Tests
    {
        const string URL = "https://www.booking.com";
        const string TEST_EMAIL = "testbookingaccount@mail.ru";
        const string TEST_PASSWORD = "Guesspassword";
        const string TEST_CITY = "Лондон";

        IWebDriver webDriver = new ChromeDriver();

        HomeBookingPage homeBookingPage;
        HomePageAfterChangeToEnglish afterChangeToEnglishPage;
        AirPassagePage airPassagePage;
        AccountLoginEmailPage accountLoginEmail;
        AccountLoginPasswordPage accountLoginPassword;
        HomeBookingPageAfterLoginAccount afterLoginAccount;
        PersonalAreaPage personalAreaPage;

        [OneTimeSetUp]
        public void TestInit()
        {
            webDriver.Navigate().GoToUrl(URL);
            homeBookingPage = new HomeBookingPage(webDriver);
        }

        [TestCase]
        public void ChangeLanguageToEnglishPositive()
        {
            homeBookingPage.Language.Click();
            IWebElement changeToEnglishButton = homeBookingPage.GetWebElement(By.XPath("//span[contains(@lang,'en-us')]"));
            changeToEnglishButton.Click();
            afterChangeToEnglishPage = new HomePageAfterChangeToEnglish(webDriver);
            Assert.IsTrue(afterChangeToEnglishPage.Language.Displayed);
        }

        [TestCase]
        public void GoingToAirPassagePagePositive()
        {
            afterChangeToEnglishPage.Language.Click();
            IWebElement changeToEnglishButton = homeBookingPage.GetWebElement(By.XPath("//span[contains(@lang,'ru')]"));
            changeToEnglishButton.Click();

            homeBookingPage = new HomeBookingPage(webDriver);
            homeBookingPage.AirPassage.Click();
            airPassagePage = new AirPassagePage(webDriver);
            Assert.IsTrue(airPassagePage.Title.Displayed);
        }

        [TestCase]
        public void LoginAccountPositive()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(URL);
            homeBookingPage = new HomeBookingPage(webDriver);
            homeBookingPage.LoginToAccount.Click();

            accountLoginEmail = new AccountLoginEmailPage(webDriver);
            accountLoginEmail.Email.SendKeys(TEST_EMAIL + Keys.Enter);

            accountLoginPassword = new AccountLoginPasswordPage(webDriver);
            accountLoginPassword.Password.SendKeys(TEST_PASSWORD + Keys.Enter);

            afterLoginAccount = new HomeBookingPageAfterLoginAccount(webDriver);
            afterLoginAccount.User.Click();
            IWebElement personalArea = homeBookingPage.GetWebElement(By.XPath("//a[contains(text(),'кабинет')]"));
            personalArea.Click();

            personalAreaPage = new PersonalAreaPage(webDriver);
            Assert.IsTrue(personalAreaPage.UserName.Displayed);
        }

        [TestCase]
        public void IsWorkingFilterPositive()
        {
            webDriver.Navigate().GoToUrl(URL);

            homeBookingPage = new HomeBookingPage(webDriver);
            homeBookingPage.City.SendKeys(TEST_CITY);
            homeBookingPage.Date.Click();

            IWebElement dateFrom = homeBookingPage.GetWebElement(By.XPath("//span[contains(text(),'25')]"));
            IWebElement dateTo = homeBookingPage.GetWebElement(By.XPath("//span[contains(text(),'27')]"));
            dateFrom.Click();
            dateTo.Click();

            homeBookingPage.Peoples.Click();
            IWebElement child = homeBookingPage.GetWebElement(By.XPath("//button[contains(@aria-label,'Детей')][2]"));
            child.Click();

            homeBookingPage.Checker.Click();
            LondonFilterPage londonFilter = new LondonFilterPage(webDriver);
            Assert.IsTrue(londonFilter.Title.Displayed);
            webDriver.Quit();
        }
        [OneTimeTearDown]
        public void TestEnd()
        {
            webDriver.Quit();
        }
    }
}