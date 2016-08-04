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
using TC_BookStore.TestInputData;
using TC_BookStore.TestData;

namespace TC_BookStore.TestCases
{
    [TestFixture]
    class RegisterTests
    {
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
            MainPage mainPage = new MainPage(browser.driver);
            mainPage.NavigateTo();

            //Click on Registration link in header
            RegisterationPage registerPage = mainPage.pageHeader.ClickRegisterLink();
            

            //Register the user.
            registerPage.RegisterUser("1");
            var userData = RegisterationData.GetTestData("1");
            //Assert user is registered successfully

            Assert.AreEqual(browser.driver.Url, ConfigurationManager.AppSettings["RedirectURL"]);
            LoginPage loginPage = mainPage.pageHeader.ClickLoginLink();
            ShoppingCartPage shoppingCart = loginPage.SignIn("admin", "admin");
            AdminPage Admin = mainPage.pageHeader.ClickAdminLink();
            MembersPage Members = Admin.ClickOnMembers();
            Assert.True(Members.UserExists(userData.Username));
            

            //Delete user from list
            Members.DeleteUser(userData.Username);
            Assert.False(Members.UserExists(userData.Username));
            
        }

        [TearDown]
        public void End()
        {

            browser.driver.Quit();
        }

    }
}


