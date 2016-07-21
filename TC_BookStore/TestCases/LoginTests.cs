using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using TC_BookStore.PageObjects;
using System.Configuration;

namespace TC_BookStore
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Start()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }

        [TearDown]
        public void End()
        {
            _driver.Quit();
        }

        [Test]
        public void LoginWithAdmin()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.NavigateTo();
            LoginPage loginPage =  mainPage.ClickOnLoginLink();
            loginPage.FillLoginData("admin", "admin");
        }
    }
}
