using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TC_BookStore.SuperClasses;
using TC_BookStore.TestData;
using TC_BookStore.TestInputData;

namespace TC_BookStore.PageObjects
{
    public class RegisterationPage: Page
    {
        private IWebDriver driver;

        #region Web Elements

        [FindsBy(How = How.Id, Using = "RegForm_Title")]
        [CacheLookup]
        public IWebElement VerifyOpen { get; set; }


        [FindsBy(How = How.Id, Using = "Reg_member_login")]
        [CacheLookup]
        public IWebElement LoginUser { get; set; }


        [FindsBy(How = How.Id, Using = "Reg_member_password")]
        [CacheLookup]
        public IWebElement Password { get; set; }


        [FindsBy(How = How.Id, Using = "Reg_member_password2")]
        [CacheLookup]
        public IWebElement ConfirmPassword { get; set; }


        [FindsBy(How = How.Id, Using = "Reg_first_name")]
        [CacheLookup]
        public IWebElement Fname { get; set; }

        [FindsBy(How = How.Id, Using = "Reg_last_name")]
        [CacheLookup]
        public IWebElement Lname { get; set; }


        [FindsBy(How = How.Id, Using = "Reg_email")]
        [CacheLookup]
        public IWebElement Email { get; set; }


        [FindsBy(How = How.Id, Using = "Reg_address")]
        public IWebElement Address { get; set; }


        [FindsBy(How = How.Id, Using = "Reg_phone")]
        [CacheLookup]
        public IWebElement Phone { get; set; }


        [FindsBy(How = How.Id, Using = "Reg_card_type_id")]
        [CacheLookup]
        private IWebElement option;
        public SelectElement CCType
        { get { return new SelectElement(option); }}
   


        [FindsBy(How = How.Id, Using = "Reg_card_number")]
        [CacheLookup]
        public IWebElement CCNumber { get; set; }

        [FindsBy(How = How.Id, Using = "Reg_insert")]
        [CacheLookup]
        public IWebElement Register { get; set; }

        [FindsBy(How = How.Id, Using = "Reg_cancel")]
        [CacheLookup]
        public IWebElement Cancel { get; set; }

        [FindsBy(How = How.Id, Using = "Reg_ValidationSummary")]
        [CacheLookup]
        public IWebElement VerificationRegion { get; set; }


        #endregion

        #region Constructors
        public RegisterationPage(IWebDriver driver): base(driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #endregion

        #region Page Operations
        public void RegisterUser(string testName)

        {
            var userData = RegisterationData.GetTestData(testName);
            UserData user = new TestInputData.UserData();
            user = (UserData)userData;
            LoginUser.SendKeys(user.Username);
            Password.SendKeys(user.Password);
            ConfirmPassword.SendKeys(userData.Repassword);
            Fname.SendKeys(user.fname);
            Lname.SendKeys(user.lname);
            Email.SendKeys(user.email);
            Address.SendKeys(user.address);
            Phone.SendKeys(user.phone);
            CCType.SelectByText(user.CCType);
            CCNumber.SendKeys(user.CCNumber);
            Register.Click();
            

        }

        public string VerifyRegister()
       {
            string MsgTxt;
            MsgTxt= VerificationRegion.Text;
            return MsgTxt;
      
        }
        #endregion
    }
}
    