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
        #region Web Elements
        [FindsBy(How = How.Id, Using = "Header_Menu_Field1")]
        private IWebElement LoginPageLink { get; set; }



        [FindsBy(How = How.Id, Using = "Header_Menu_Reg")]
        private IWebElement RegisterationPageLink { get; set; }

        #endregion

        public Header pageHeader;

        private IWebDriver _driver;
        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            pageHeader = new Header(_driver);
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


        public RegisterationPage ClickOnRegisterLink()
        {
            RegisterationPageLink.Click();
            RegisterationPage registerPage = new RegisterationPage(_driver);
            return registerPage;
        }
    }
}
