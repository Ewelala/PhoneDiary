using NUnit.Framework;
using PhoneDiary.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PhoneDiary.Tests.Controllers
{    
    [TestFixture]
    public class AdressesControllerTests
    {     
        AddressesController addressController = null;
        [SetUp]
        public void StartUp()
        {            
            addressController = new AddressesController();
        }

        [Test]
        public void Index_Return_NotNull()
        {         
            var indexView = addressController.Index() as ViewResult;
            Assert.IsNotNull(indexView); 
        }
        [Test]      
        public void Edit_ReturnsBadRequest()
        {            
            var result = addressController.Edit(null as int?);
            Assert.IsInstanceOf<HttpStatusCodeResult>(result);
        }

        [Test]

        public void Delete_ReturnsHttpNotFound()
        {
            var result = addressController.Delete(-100) as ContentResult;
            string resultString = result.Content;
            Assert.AreNotEqual("success", resultString);
        }
    }
}
