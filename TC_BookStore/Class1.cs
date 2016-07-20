using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace TC_BookStore
{
    [TestFixture]
    public class Class1
    {
        //hello1
        [SetUp]
        public void Start()
        { }

        [TearDown]
        public void End()
        { }

        [Test]
        public void OpenGoogle()
        {
            IWebDriver _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl("http://10.1.23.114/BookStore");
        }
    }
}
