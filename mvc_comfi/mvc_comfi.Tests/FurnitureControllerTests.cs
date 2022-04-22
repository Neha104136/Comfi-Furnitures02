using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvc_comfi.Controllers;
using mvc_comfi.Models.comfi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.IO;

namespace mvc_comfi.tests
{
   [TestClass]
    public class FurnitureControllerTests
    {
          [TestMethod]

     public   void TestGetFurnitures()
        {
            var streamWriter = new StreamWriter("log.txt");
            //Arrange
            var context = new comfifurnituresContext();
           
            var furnitureabc = context.Furnitures.Where(a => a.Prodid == 103).FirstOrDefault();
           // streamWriter.WriteLine(furnitureabc.Prodid);

            var controller = new FurnituresController(context);

            //Act
            var furniture = controller.GetAllProducts();
            var result = furniture;

            //
            Assert.IsNotNull(result);
            streamWriter.Close();

        }
    }
}
