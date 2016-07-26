using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TC_BookStore.PageObjects
{
    public class ShoppingCartPage
    {
        [FindsBy(How = How.Id, Using = "Header_Menu_Admin")]
        private IWebElement AdminLink { get; set; }

        [FindsBy(How = How.Id, Using = "MemberForm_Title")]
        public IWebElement Header { get; set; }

        private IWebDriver _driver;
        public ShoppingCartPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public AdminPage ClickOnAdminPage()
        {
            AdminLink.Click();
            AdminPage adminPage = new AdminPage(_driver);
            return adminPage;
        }
    }
}