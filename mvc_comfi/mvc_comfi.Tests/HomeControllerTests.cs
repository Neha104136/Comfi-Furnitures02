using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvc_comfi.Controllers;

namespace mvc_comfi.tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexTest()
        {
            //Arrange

            HomeController Controller = new HomeController();
            //var Controller = new HomeController();

            //Act
            var result = Controller.Index();

            //Assert

            Assert.IsTrue(result is ViewResult, "Index Action does not return a view");

        }
        [TestMethod]
        public void PrivacyTest()
        {
            
            //Arrange
            HomeController controller = new HomeController();

            //Act
            var result = controller.Privacy();

            //assert
            Assert.IsTrue(result is ViewResult);
        }
     
    }
     
}

