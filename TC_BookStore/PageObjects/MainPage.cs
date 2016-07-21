using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;

namespace TC_BookStore.PageObjects
{
    public class MainPage
    {

        [FindsBy(How = How.Id, Using = "Header_Menu_Field1")]
        private IWebElement LoginPageLink { get; set; }

        private IWebDriver _driver;
        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseUrl"]);
        }

        public LoginPage ClickOnLoginLink()
        {
            LoginPageLink.Click();
            LoginPage loginPage = new LoginPage(_driver);
            return loginPage;
        }
    }
}
