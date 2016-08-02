using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TC_BookStore.PageObjects;
using System.Configuration;
using TC_BookStore.SuperClasses;

namespace TC_BookStore.TestCases
{
    [TestFixture]
    class RegisterTests
    {
        IWebDriver _driver;
        Browser browser;

        [SetUp]
        public void Start()
        {
            browser = new Browser();
            browser.MaximizeWindow();
            browser.setImplicitWait(30);
        }


        [Test]
        public void RegisterationTest()
        {
            //Navigate to Main page
            MainPage mainPage = new MainPage(_driver);
            mainPage.NavigateTo();

            //Click on Registration link in header
            RegisterationPage registerPage = mainPage.pageHeader.ClickRegisterLink();

            //Register the user.
            registerPage.RegisterUser("Em", "123451789", "123451789", "Eman2", "abdo2", "eman.farag3@yahoo.com", "Cairo", "01020730865", "Visa", "9018992339828");

            //Assert user is registered successfully
            Assert.AreEqual(this._driver.Url, ConfigurationManager.AppSettings["RedirectURL"]);
            LoginPage loginPage = mainPage.pageHeader.ClickLoginLink();
            ShoppingCartPage shoppingCart = loginPage.SignIn("admin", "admin");
            AdminPage Admin = mainPage.pageHeader.ClickAdminLink();
            MembersPage Members = Admin.ClickOnMembers();
            Assert.True(Members.UserExists("Em"));
            browser.setImplicitWait(30);

            //Delete user from list
            Members.DeleteUser("Em");
            Assert.False(Members.UserExists("Em"));
            browser.setImplicitWait(30);
        }

        [TearDown]
        public void End()
        {

            browser.driver.Quit();
        }

    }
}


