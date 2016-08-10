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
using TC_BookStore.SuperClasses;

namespace TC_BookStore
{
    [TestFixture]
    public class LoginTests
    {
        private Browser browser;

        [SetUp]
        public void Start()
        {
            browser = new Browser();
            browser.MaximizeWindow();
            browser.setImplicitWait(30);
        }

        [TearDown]
        public void End()
        {
            browser.driver.Quit();
        }

        [TestCase("admin","admin")]
        [TestCase("guest", "guest")]

        public void Login(string usrname, string password)
        {
            //
            MainPage mainPage = new MainPage(browser.driver);
            mainPage.NavigateTo();
            LoginPage loginPage = mainPage.pageHeader.ClickLoginLink();
            ShoppingCartPage shoppingCart = loginPage.SignIn(usrname, password);
            Assert.AreEqual("User Information", shoppingCart.Header.Text);
        }
    }
}
