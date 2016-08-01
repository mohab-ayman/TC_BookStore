using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TC_BookStore.SuperClasses;

namespace TC_BookStore.PageObjects
{
    public class ShoppingCartPage: Page
    {

        #region Web Elements
        [FindsBy(How = How.Id, Using = "Header_Menu_Admin")]
        private IWebElement AdminLink { get; set; }

        [FindsBy(How = How.Id, Using = "MemberForm_Title")]
        public IWebElement Header { get; set; }


        #endregion

        #region Constructors
        public ShoppingCartPage(IWebDriver driver): base(driver)
        {
           
            PageFactory.InitElements(_driver, this);
        }

        #endregion

        #region Page Operations
        public AdminPage ClickOnAdminPage()
        {
            AdminLink.Click();
            AdminPage adminPage = new AdminPage(_driver);
            return adminPage;
        }

        #endregion
    }
}