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
    class Register_Testcase
    {
        [TestFixture]
        public class NUnitTest
        {
            IWebDriver driver;

            [SetUp]
            public void Start()
            {
                driver = new FirefoxDriver();
            }


            [Test]
            public void RegisterationTest()
            {
              
                MainPage mainPage = new MainPage(driver);
                ShoppingCartPage ShopCart = new ShoppingCartPage(driver);
                mainPage.NavigateTo();
                RegisterationPage registerPage = mainPage.ClickOnRegisterLink();
                registerPage.RegisterUser("Emzy5", "123451788", "123451788", "Eman2", "abdo12", "eman.farag3@yahoo.com", "Cairo", "01020730816", "Visa", "9018992339828");
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
           
                Assert.AreEqual(this.driver.Url, ConfigurationManager.AppSettings["RedirectURL"]);
                LoginPage loginPage = mainPage.ClickOnLoginLink();
                loginPage.FillLoginData("admin", "admin");
                ShoppingCartPage shoppingCart = loginPage.SignIn();
                AdminPage Admin = ShopCart.ClickOnAdminPage();
                MembersPage Members = Admin.ClickOnMembers();
                Assert.True(Members.UserExists("Emzy5"));
        
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            }

            [TearDown]
            public void End()
            {
                driver.Quit();
            }

        }
    }
}

