using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TC_BookStore.SuperClasses;

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
        public void RegisterUser(string username, string password, string repassword, string fname, string lname, string email, string addr, string phone, string ccType, string CCno)

        {
            LoginUser.SendKeys(username);
            Password.SendKeys(password);
            ConfirmPassword.SendKeys(repassword);
            Fname.SendKeys(fname);
            Lname.SendKeys(lname);
            Email.SendKeys(email);
            Address.SendKeys(addr);
            Phone.SendKeys(phone);
            CCType.SelectByText(ccType);
            CCNumber.SendKeys(CCno);
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
    