using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TC_BookStore.PageObjects
{
  
    public class InsertPage
    {

        [FindsBy(How = How.Id, Using = "Categories_name")]
        private IWebElement NameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "Categories_insert")]
        private IWebElement InsertButton { get; set; }

        private IWebDriver _driver;
        public InsertPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public CategoriesPage FillCatName (string cat)
        {
            NameTextBox.SendKeys(cat);
            InsertButton.Click();
            CategoriesPage categoriesPage = new CategoriesPage(_driver);
            return categoriesPage;
        }
    }
}
