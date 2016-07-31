using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC_BookStore.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TC_BookStore.SuperClasses
{
    public class Page
    {
        public Header pageHeader;
        public IWebDriver _driver;

        public Page(IWebDriver driver)
        {
            _driver = driver;
            pageHeader = new Header(_driver);
        }
    }
}
