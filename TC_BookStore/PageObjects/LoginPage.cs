using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TC_BookStore.SuperClasses;

namespace TC_BookStore.PageObjects
{
    public class LoginPage : Page
    {
        [FindsBy(How = How.Id, Using = "Login_name")]
        private IWebElement UserNameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "Login_password")]
        private IWebElement PasswordTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "Login_login")]
        private IWebElement LoginButton { get; set; }

        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        public ShoppingCartPage SignIn(string username, string password)
        {
            UserNameTextBox.SendKeys(username);
            PasswordTextBox.SendKeys(password);
            LoginButton.Click();
            ShoppingCartPage shoppingCart = new ShoppingCartPage(_driver);
            return shoppingCart;
        }

        public AdminPage SignInFromAdminPage(string username, string password)
        {
            UserNameTextBox.SendKeys(username);
            PasswordTextBox.SendKeys(password);
            LoginButton.Click();
            AdminPage adminPage = new AdminPage(_driver);
            return adminPage;
        }
    }
}
