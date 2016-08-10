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
    public class CategoriesPage : Page
    {
        #region Web Elements
        [FindsBy(How = How.Id, Using = "Categories_insert")]
        private IWebElement CatInsert { get; set; }

        [FindsBy(How = How.Id, Using = "Categories_delete")]
        private IWebElement CatDelete { get; set; }
        #endregion

        #region Constructors
        public CategoriesPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
        }
        #endregion

        #region Page Operations
        public InsertPage ClickOnInsert()
        {
            CatInsert.Click();
            InsertPage insertPage = new InsertPage(_driver);
            return insertPage;
        }

        // COMMENT: Adjust this to just return the findElement.displayed result

        public Boolean CheckCategory(string cat)
        {
            if (_driver.FindElement(By.LinkText(cat)).Displayed)
                return true;
            else
                return false;
        }

        public void deleteCategory (string Category)
        {
            _driver.FindElement(By.LinkText(Category)).Click();
            CatDelete.Click();

        }
        #endregion
    }
}
