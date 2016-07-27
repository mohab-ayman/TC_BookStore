using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TC_BookStore.PageObjects
{
    public class Header
    {
        #region Locators

        [FindsBy(How = How.Id, Using = "Header_Menu_Field2")]
        private IWebElement SiteLogo { get; set; }

        [FindsBy(How = How.Id, Using = "Header_Menu_Home")]
        private IWebElement HomeLink { get; set; }

        [FindsBy(How = How.Id, Using = "Header_Menu_Reg")]
        private IWebElement RegisterLink { get; set; }

        [FindsBy(How = How.Id, Using = "Header_Menu_Shop")]
        private IWebElement ShopCartLink { get; set; }

        [FindsBy(How = How.Id, Using = "Header_Menu_Field1")]
        private IWebElement LoginLink { get; set; }

        [FindsBy(How = How.Id, Using = "Header_Menu_Admin")]
        private IWebElement AdminLink { get; set; }

        #endregion

        private IWebDriver _driver;

        public Header(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public MainPage ClickSiteLogo()
        {
            SiteLogo.Click();
            MainPage mainPage = new MainPage(_driver);
            return mainPage;
        }

        public MainPage ClickHomeLink()
        {
            HomeLink.Click();
            MainPage mainPage = new MainPage(_driver);
            return mainPage;
        }

        public RegisterationPage ClickRegisterLink()
        {
            RegisterLink.Click();
            RegisterationPage regPage = new RegisterationPage(_driver);
            return regPage;
        }

        public ShoppingCartPage ClickShopCartLink()
        {
            ShopCartLink.Click();
            ShoppingCartPage shopPage = new ShoppingCartPage(_driver);
            return shopPage;
        }

        public LoginPage ClickLoginLink()
        {
            LoginLink.Click();
            LoginPage loginPage = new LoginPage(_driver);
            return loginPage;
        }

        public AdminPage ClickAdminLink()
        {
            AdminLink.Click();
            AdminPage adminPage = new AdminPage(_driver);
            return adminPage;
        }
    }
}
