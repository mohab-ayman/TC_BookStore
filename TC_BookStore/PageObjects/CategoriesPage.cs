using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TC_BookStore.PageObjects
{
    public class CategoriesPage
    {
        [FindsBy(How = How.Id, Using = "Categories_insert")]
        private IWebElement CatInsert { get; set; }

        private IWebDriver _driver;
        public CategoriesPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public InsertPage ClickOnInsert()
        {
            CatInsert.Click();
            InsertPage insertPage = new InsertPage(_driver);
            return insertPage;
        }
    }
}
