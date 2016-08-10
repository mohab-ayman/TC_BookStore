using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using TC_BookStore.SuperClasses;


namespace TC_BookStore.PageObjects
{
    public class AdvancedSearchPage: Page
    {
        private SelectElement _select;
        #region Web Elements
        [FindsBy(How = How.Id, Using = "Search_name")]
        private IWebElement Title { get; set; }
        [FindsBy(How = How.Id, Using = "Search_author")]
        private IWebElement Author { get; set; }
        [FindsBy(How = How.Id, Using = "Search_category_id")]
        private IWebElement Category { get; set; }
        [FindsBy(How = How.Id, Using = "Search_pricemin")]
        private IWebElement MinPrice { get; set; }
        [FindsBy(How = How.Id, Using = "Search_pricemax")]
        private IWebElement MaxPrice { get; set; }
        [FindsBy(How = How.Id, Using = "Search_search_button")]
        private IWebElement Search { get; set; }


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
            Title.SendKeys(title);
            Author.SendKeys(author);
            _select = new SelectElement(Category);
            IList<IWebElement> Categories = _select.Options;
            foreach (IWebElement catg in Categories)
            {
                if (category.Equals(catg.Text))
                {
                    _select.SelectByText(catg.Text);
                    break;

                }
                else
                {
                    _select.SelectByText("All");

                }

            }
            MinPrice.SendKeys(minprice);
            MaxPrice.SendKeys(maxprice);
            Search.Click();
        }
        public Boolean BookExists(string title)
        {
            try
            {
                return _driver.FindElement(By.XPath(".//*[@id='Results_holder']/tbody/tr[3]/td/table/tbody/tr[2]/td[2]/table/tbody/tr[1]/td/font/b")).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }

        public string GetBooktitle()
        {
                string Bktitle =_driver.FindElement(By.XPath(".//*[@id='Results_holder']/tbody/tr[3]/td/table/tbody/tr[2]/td[2]/table/tbody/tr[1]/td/font/b")).Text;
                return Bktitle;
        }
        #endregion
    }
}
