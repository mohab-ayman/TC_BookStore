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
    public class AdminPage : Page
    {
        #region Web Elements
        [FindsBy(How = How.Id, Using = "Form_Field4")]
        private IWebElement Categories { get; set; }

        [FindsBy(How = How.Id, Using = "Form_Field1")]
        private IWebElement Members { get; set; }
        #endregion

        #region Constructors
        public AdminPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
        }
        #endregion

        #region Page Operations
        public CategoriesPage ClickOnCategories()
        {
            Categories.Click();
            CategoriesPage categoriesPage = new CategoriesPage(_driver);
            return categoriesPage;
        }

        public MembersPage ClickOnMembers()
        {
            Members.Click();
            MembersPage MembersPage = new MembersPage(_driver);
            return MembersPage;
        }
        #endregion
    }
}
