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
    public class AdvancedSearchPage: Page
    {
        #region Web Elements
        [FindsBy(How = How.Id, Using = "Search_name")]
        private IWebElement BTitle { get; set; }
        [FindsBy(How = How.Id, Using = "Search_author")]
        private IWebElement BAuthor { get; set; }
        [FindsBy(How = How.Id, Using = "Search_category_id")]
        private IWebElement BCategory { get; set; }
        [FindsBy(How = How.Id, Using = "Search_pricemin")]
        private IWebElement BMinPrice { get; set; }
        [FindsBy(How = How.Id, Using = "Search_pricemax")]
        private IWebElement BMaxPrice { get; set; }
        [FindsBy(How = How.Id, Using = "Search_search_button")]
        private IWebElement Search { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='Results_holder']/tbody/tr[3]/td/table/tbody/tr[2]/td[2]/table/tbody/tr[1]/td/font/b")]
        private IWebElement Btitle_Result { get; set; }

        #endregion

        #region Constructors
        public AdvancedSearchPage(IWebDriver driver): base(driver)
        {

            PageFactory.InitElements(_driver, this);
        }

        #endregion

        #region Page Operations
        public void SearchForBooks(string title,string author,string category,string minprice, string maxprice)
        {
            BTitle.SendKeys(title);
            BAuthor.SendKeys(author);
            BCategory.SendKeys(category);
            BMinPrice.SendKeys(minprice);
            BMaxPrice.SendKeys(maxprice);
            Search.Click();
        }

        public string BookExists()
        {
          
                string Bktitle =_driver.FindElement(By.XPath(".//*[@id='Results_holder']/tbody/tr[3]/td/table/tbody/tr[2]/td[2]/table/tbody/tr[1]/td/font/b")).Text;
                return Bktitle;
            
           
        }
        #endregion
    }
}
