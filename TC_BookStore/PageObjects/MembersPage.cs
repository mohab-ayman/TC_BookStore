using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TC_BookStore.PageObjects
{
    public class MembersPage
    {
        //[FindsBy(How = How.LinkText, Using = )]
        //private IWebElement UserRegistered { get; set; }

        private IWebDriver _driver;
        public MembersPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

    }



}
