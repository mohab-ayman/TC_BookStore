using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using TC_BookStore.PageObjects;
using System.Configuration;
using TC_BookStore.SuperClasses;

namespace TC_BookStore.TestCases
{
    [TestFixture]
    class AdminTests
    {
        private IWebDriver _driver;
        private Browser browser;

        [SetUp]
        public void Start()
        {
            browser = new Browser();
            browser.MaximizeWindow();
            browser.setImplicitWait(30);
        }

        [TearDown]
        public void End()
        {
            browser.driver.Quit();

        }
        [Test]
        public void InsertCategory()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.NavigateTo();
            LoginPage loginPage = mainPage.ClickOnLoginLink();
            ShoppingCartPage shoppingCart = loginPage.SignIn("admin", "admin");
            AdminPage adminPage = shoppingCart.ClickOnAdminPage();
            CategoriesPage categoriesPage = adminPage.ClickOnCategories();
            InsertPage insertPage = categoriesPage.ClickOnInsert();
            categoriesPage = insertPage.FillCatName("New Category1");
            insertPage = categoriesPage.ClickOnInsert();
            categoriesPage = insertPage.FillCatName("New Category2");
            Assert.True(categoriesPage.CheckCategory("New Category1"));
        }

    }
}
