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
  
    public class InsertPage : Page
    {
        #region Web Elements

        [FindsBy(How = How.Id, Using = "Categories_name")]
        private IWebElement NameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "Categories_insert")]
        private IWebElement InsertButton { get; set; }

        #endregion

        #region Constructors
        public InsertPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #endregion

        #region Page Operations
        public CategoriesPage FillCatName (string cat)
        {
            NameTextBox.SendKeys(cat);
            InsertButton.Click();
            CategoriesPage categoriesPage = new CategoriesPage(_driver);
            return categoriesPage;
        }
        #endregion
    }
}
