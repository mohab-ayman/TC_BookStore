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
            IWebDriver driver;

            [SetUp]
            public void Start()
            {
                driver = new FirefoxDriver();
            }


            [Test]
            public void RegisterationTest()
            {
                Header header = new Header(driver);
                RegisterationPage registerPage = header.ClickRegisterLink();
                registerPage.RegisterUser("Mony", "123451789", "123451789", "Eman122", "abdo12", "eman.farag3@yahoo.com", "Cairo", "01020730815", "Visa", "9018992339828");
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
           
                Assert.AreEqual(this.driver.Url, ConfigurationManager.AppSettings["RedirectURL"]);
                LoginPage loginPage = header.ClickLoginLink();
                ShoppingCartPage shoppingCart = loginPage.SignIn("admin", "admin");
                AdminPage Admin = header.ClickAdminLink();
                MembersPage Members = Admin.ClickOnMembers();
                Assert.True(Members.UserExists("Mony"));
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                Members.DeleteUser("Mony");
                Assert.False(Members.UserExists("Mony"));

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            }

            [TearDown]
            public void End()
            {
               
                driver.Quit();
            }

        }
    }


