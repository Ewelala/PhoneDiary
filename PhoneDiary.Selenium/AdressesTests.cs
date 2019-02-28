using NUnit.Framework;
using PhoneDiary.Selenium.CancretePage;
namespace PhoneDiary.Selenium
{
    [TestFixture]
    public class AdressesTests : MainTest
    {
        [Test]
        public void CreateNew()
        {
            var pageAdresses = new PageAdresses(_driver);
            pageAdresses.Create.Click();
            var pageCreate = new PageAdressesCreate(_driver);
            pageCreate.Street.SendKeys("Jana Pawła II");
            pageCreate.City.SendKeys("Kraków");
            pageCreate.Country.SendKeys("Polska");
            pageCreate.Submit.Submit();

            Assert.IsTrue(pageAdresses.HeaderAdresses.Displayed);
            Assert.AreEqual("Adresy", pageAdresses.HeaderAdresses.Text);

        }
        [Test]
        public void GoToEdit()
        {
            var pageAdresses = new PageAdresses(_driver);
            var edit = pageAdresses.Edit;
            edit.Click();
            Assert.IsTrue(pageAdresses.EditHeader.Displayed);
            StringAssert.StartsWith("Edycja", pageAdresses.EditHeader.Text);

        }
    }
}
