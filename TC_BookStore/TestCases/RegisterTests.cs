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
                mainPage.NavigateTo();
                RegisterationPage registerPage = mainPage.ClickOnRegisterLink();
                registerPage.RegisterUser(login, "123456789", "123456789", "Eman", "abdo22", "eman.farag22@yahoo.com", "Cairo", "01020730819", "Visa", "90182992339828");
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
               // if( == "")
                {

                }
                Assert.AreEqual(this.driver.Url, ConfigurationManager.AppSettings["RedirectURL"]);
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

