using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDiary.Selenium.CancretePage
{
    public class PageAdresses
    {
        const string URL = "http://localhost:11111/Addresses";
        private IWebDriver _driver;
        public PageAdresses(IWebDriver driver)
        {
            _driver = driver;
            _driver.Url = URL;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "CreateBtn")]
        public IWebElement Create { get; set; }

        [FindsBy(How = How.TagName, Using = "h2")]
        public IWebElement HeaderAdresses { get; set; } 

        [FindsBy(How = How.XPath, Using = "//a[text()='Edytuj']")]
        public IWebElement Edit { get; set; }


        [FindsBy(How = How.TagName, Using = "h4")]
        public IWebElement EditHeader { get; set; }
      

    }
}
