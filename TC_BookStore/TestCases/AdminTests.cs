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

namespace TC_BookStore.TestCases
{
    [TestFixture]
    class AdminTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Start()
        {
            _driver = new FirefoxDriver();
        }

        [TearDown]
        public void End()
        {
            _driver.Quit();
        }
        [Test]
        public void InsertCategory()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.NavigateTo();
            LoginPage loginPage = mainPage.ClickOnLoginLink();
            loginPage.FillLoginData("admin", "admin");
            ShoppingCartPage shoppingCart = loginPage.SignIn();
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
