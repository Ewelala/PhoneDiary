using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDiary.Selenium.CancretePage
{
    public class PageAdressesCreate
    {
        const string URL = "http://localhost:11111/Addresses/Create";
        private IWebDriver _driver;
        public PageAdressesCreate(IWebDriver driver)
        {
            _driver = driver;
            _driver.Url = URL;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "Street")]
        public IWebElement Street { get; set; }
        [FindsBy(How = How.Id, Using = "City")]
        public IWebElement City { get; set; }
        [FindsBy(How = How.Id, Using = "Country")]
        public IWebElement Country { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Utwórz']")]
        public IWebElement Submit { get; set; }
    }
}
