using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TC_BookStore.PageObjects;
using System.Configuration;
using TC_BookStore.SuperClasses;
using TC_BookStore.TestInputData;
using TC_BookStore.TestData;
using System.Threading;

namespace TC_BookStore.TestCases
{
    [TestFixture]
    class SearchBooks
    {
        Browser browser;

        [SetUp]
        public void Start()
        {
            browser = new Browser();
            browser.MaximizeWindow();
            browser.setImplicitWait(30);
        }

       
        [TestCase("Beginning Active Server Pages 3.0", "David Buser","Programming","29.10","32.00")]
        [TestCase("Mastering ColdFusion 4.5", "Kristin Motlagh", "Programming","38.00","40.00")]
        public void SearchForbooksTest(string title, string author, string category, string maxprice, string minprice)
        {
            //Navigate to Main page
            MainPage mainPage = new MainPage(browser.driver);
            mainPage.NavigateTo();

            //Click on AdvanceSearch link in HomePage
            AdvancedSearchPage AdvSearchPage = mainPage.ClickOnAdvSearchLink();

            //Search for books using Advance Search.
            AdvSearchPage.SearchForBooks(title,author,category,maxprice,minprice);

            //Assert the book under search is returned successfully
            Assert.True(AdvSearchPage.BookExists(title));

            //Assert book title displayed match book title in search criteria
            string Btitle = AdvSearchPage.GetBooktitle();
            Assert.AreEqual(Btitle, title);
        }

        [TearDown]
        public void End()
        {

            browser.driver.Quit();
        }


    }
}
