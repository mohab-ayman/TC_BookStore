using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Configuration;

namespace TC_BookStore.SuperClasses
{
    public class Browser
    {
        public IWebDriver driver;
        public Browser()
        {
            string type = ConfigurationManager.AppSettings["Browser"];
            switch (type)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new FirefoxDriver();
                    break;
            }
        }

        public void setImplicitWait(int seconds)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }

        public void MaximizeWindow()
        {
            driver.Manage().Window.Maximize();
        }

        public void goTo(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }
    }
}
