using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using PhoneDiary;
using PhoneDiary.Controllers;

namespace PhoneDiary.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        HomeController homeController = null;
        [SetUp]
        public void StartUp()
        {
            homeController = new HomeController();
        }
        [Test]
        public void IndexIsNotNull()
        {    
            ViewResult result = homeController.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void AboutMessageOK()
        {            
            ViewResult result = homeController.About() as ViewResult;
            Assert.AreEqual("Super Aplikacja", result.ViewBag.Message);
        }

        [Test]
        public void ContactIsNotNull()
        {   
            ViewResult result = homeController.Contact() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
