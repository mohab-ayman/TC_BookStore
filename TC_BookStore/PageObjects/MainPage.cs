using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using TC_BookStore.SuperClasses;

namespace TC_BookStore.PageObjects
{
    public class MainPage : Page
    {
        #region Web Elements
        [FindsBy(How = How.Id, Using = "Header_Menu_Field1")]
        private IWebElement LoginPageLink { get; set; }

        [FindsBy(How = How.Id, Using = "Header_Menu_Reg")]
        private IWebElement RegisterationPageLink { get; set; }

        [FindsBy(How = How.Id, Using = "AdvMenu_Field1")]
        private IWebElement AdvanceSearchPageLink { get; set; }
        #endregion

        #region Constructors
        public MainPage(IWebDriver driver) : base (driver)
        {
            PageFactory.InitElements(_driver, this);
        }
        #endregion

        #region Page Operations
        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseUrl"]);
        }



        public AdvancedSearchPage ClickOnAdvSearchLink()
        {
            AdvanceSearchPageLink.Click();
            AdvancedSearchPage AdvSearchPage = new AdvancedSearchPage(_driver);
            return AdvSearchPage;
        }

    #endregion
}
}
