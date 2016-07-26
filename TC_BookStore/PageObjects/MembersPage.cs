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
        private IWebDriver _driver;
        public MembersPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public Boolean UserExists(string userName)
        {
            return _driver.FindElement(By.LinkText(userName)).Displayed;
        }
    }



}
