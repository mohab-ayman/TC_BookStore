using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TC_BookStore.PageObjects
{
    public class AdminPage
    {
        [FindsBy(How = How.Id, Using = "Form_Field4")]
        private IWebElement Categories { get; set; }

        private IWebDriver _driver;
        public AdminPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public CategoriesPage ClickOnCategories()
        {
            Categories.Click();
            CategoriesPage categoriesPage = new CategoriesPage(_driver);
            return categoriesPage;
        }


    }
}
