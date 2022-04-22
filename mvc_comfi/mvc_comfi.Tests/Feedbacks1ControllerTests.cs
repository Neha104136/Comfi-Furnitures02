using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvc_comfi.Controllers;
using mvc_comfi.Models.comfi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace mvc_comfi.Tests
{
    [TestClass]
    public class Feedbacks1ControllerTests
    {
        [TestMethod]
        public void TestFeedback()
        {
            
            //Arrange
            var context = new comfifurnituresContext();
            var controller = new Feedbacks1Controller(context);
            var bkapt = new Feedback()
            {
                Id = 1,
                FirstName = "navnath",
                LastName = "ghuge",
                Email = "navnath@mastek.com",
                Suggestions = "hello"

            };



            //Act
            var result = controller.PostFeedback(bkapt);
            // var furnitures = context.Feedbacks.Where(a => a.FirstName.Equals("navnath")).FirstOrDefault();
            var furnitures = context.Feedbacks.Where(fur => fur.FirstName.Equals("navnath")).FirstOrDefault();



            //Assert
            Assert.AreEqual(result, furnitures.FirstName, message:
    "The entry saved is not as per what was returned");
        }

    }


}

