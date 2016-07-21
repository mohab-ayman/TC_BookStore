using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TC_BookStore.PageObjects
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "Login_name")]
        private IWebElement UserNameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "Login_password")]
        private IWebElement PasswordTextBox { get; set; }

        private IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void FillLoginData(string username, string password)
        {
            UserNameTextBox.SendKeys(username);
            PasswordTextBox.SendKeys(password);
        }
    }
}
