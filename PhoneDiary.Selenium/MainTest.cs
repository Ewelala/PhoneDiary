using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDiary.Selenium
{
    [TestFixture]
    public abstract class MainTest
    {
        public IWebDriver _driver { private set; get; }
        [SetUp]
        public void Start()
        {
            _driver = new FirefoxDriver();
        }
        [TearDown]
        public void Stop()
        {
            _driver.Close();
        }
    }
}
