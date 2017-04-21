using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPizza.Controllers;
using ASPizza.Models;
using ASPizzaUnitTest.Doubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ASPizzaUmitTest.Tests
{
    [TestClass]
   public class DodatekControllerTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DisplayByIdException()
        {
            var context = new FakePizzaSharingContext();
            context.Dodatki = new[]
            {
                new Dodatek { Id = 1, Name="Cebula"},
            }.AsQueryable();

            var controller = new DodatekController(context);
            var result = controller.DisplayById(25);
            Assert.AreEqual(typeof(Exception), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EditViewException()
        {
            var context = new FakePizzaSharingContext();
            context.Dodatki = new[]
            {
                new Dodatek { Id = 1, Name="Cebula"},
            }.AsQueryable();

            var controller = new DodatekController(context);
            var result = controller.Edit(25);
            Assert.AreEqual(typeof(Exception), result.GetType());
        }
    }
}