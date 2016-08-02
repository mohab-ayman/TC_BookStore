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

namespace TC_BookStore.TestCases
{
    [TestFixture]
    class RegisterTests
    {
        IWebDriver _driver;

        [SetUp]
        public void Start()
        {
            _driver = new FirefoxDriver();
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
            registerPage.RegisterUser("Mony", "123451789", "123451789", "Eman122", "abdo12", "eman.farag3@yahoo.com", "Cairo", "01020730815", "Visa", "9018992339828");
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));

            Assert.AreEqual(this._driver.Url, ConfigurationManager.AppSettings["RedirectURL"]);
            LoginPage loginPage = header.ClickLoginLink();
            ShoppingCartPage shoppingCart = loginPage.SignIn("admin", "admin");
            AdminPage Admin = header.ClickAdminLink();
            MembersPage Members = Admin.ClickOnMembers();
            Assert.True(Members.UserExists("Mony"));
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            Members.DeleteUser("Mony");
            Assert.False(Members.UserExists("Mony"));

            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
        }

        [TearDown]
        public void End()
        {

            _driver.Quit();
        }

    }
}


