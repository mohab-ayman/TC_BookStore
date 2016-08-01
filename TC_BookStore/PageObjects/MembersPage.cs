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
    public class MembersPage : Page
    {

        #region Web Elements

        [FindsBy(How = How.Id, Using = "Members_delete")]
        [CacheLookup]
        public IWebElement DeleteBtn { get; set; }


        [FindsBy(How = How.Id, Using = "Record_member_login")]
        [CacheLookup]
        public IWebElement UserLink { get; set; }
        #endregion

        #region Constructors

        public MembersPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #endregion

        #region Page Operations
        public Boolean UserExists(string userName)
        {
            try
            {
                return _driver.FindElement(By.LinkText(userName)).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }

        public void DeleteUser(string userName)
        {
            _driver.FindElement(By.LinkText(userName)).Click();
            UserLink.Click();
            DeleteBtn.Click();
        }

        #endregion
    }



}

