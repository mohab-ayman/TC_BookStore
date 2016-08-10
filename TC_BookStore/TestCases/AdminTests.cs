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


        [TestCase("category1")]
        [TestCase("category2")]


        public void InsertCategory(string category)
        {
            // Home page
            MainPage mainPage = new MainPage(browser.driver);
            mainPage.NavigateTo();

            // Login Page
            LoginPage loginPage = mainPage.ClickOnLoginLink();

            // Shopping Cart
            ShoppingCartPage shoppingCart = loginPage.SignIn("admin", "admin");

            // Admin Page
            AdminPage adminPage = shoppingCart.ClickOnAdminPage();

            // Categories page
            CategoriesPage categoriesPage = adminPage.ClickOnCategories();

            // Insert page
            InsertPage insertPage = categoriesPage.ClickOnInsert();

            // Back to categories page after insert new category
            categoriesPage = insertPage.FillCatName(category);
            
            // Assert on the inserted category
            Assert.True(categoriesPage.CheckCategory(category));

            categoriesPage.deleteCategory(category);
        }

    }
}
