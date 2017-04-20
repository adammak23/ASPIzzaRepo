using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ASPizza.Models;
using ASPizza.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace ASPizzaUnitTest.Tests
{
    [TestClass]
     public class DodatekMoqTest
    {
        [TestMethod]
        public void TestDisplayDodatekByIdMoq()
        {
            Dodatek dodatek = new Dodatek();
            dodatek.Id = 5;
            dodatek.Name = "Pepperoni";
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindDodatekById(2)).Returns(dodatek);
            var controller = new DodatekController(context.Object);

            var result = controller.DisplayById(2) as ViewResult;

            Assert.AreEqual("Display", result.ViewName);
            var resultDodatek = (Dodatek)result.Model;
            Assert.AreEqual("Pepperoni", resultDodatek.Name);
        }

        [TestMethod]
        public void TestEditDodatekMoq()
        {
            Dodatek dodatek = new Dodatek();
            dodatek.Id = 4;
            dodatek.Name = "Oliwki";
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindDodatekById(2)).Returns(dodatek);
            var controller = new DodatekController(context.Object);


            var result = controller.Edit(2) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
            var resultDodatek = (Dodatek)result.Model;
            Assert.AreEqual("Oliwki", resultDodatek.Name);
        }

        [TestMethod]
        public void TestEditConfDodatekMoq()
        {
            Dodatek dodatek = new Dodatek();
            dodatek.Name = "Ananak";
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindDodatekById(2)).Returns(dodatek);
            context.Setup(s => s.SaveChanges()).Returns(0);
            var controller = new DodatekController(context.Object);

            dodatek.Name = "Ananas";
            dodatek.Id = 2;
            var result = controller.Edit(dodatek) as RedirectToRouteResult;

            Assert.AreEqual("All", result.RouteValues["Action"]);
            Assert.AreEqual("Pizza", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestEditModelNotValidMoq()
        {
            Dodatek dodatek = new Dodatek();
            dodatek.Name = "Oregano";
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindDodatekById(2)).Returns(dodatek);
            context.Setup(s => s.SaveChanges()).Returns(0);
            var controller = new DodatekController(context.Object);
            dodatek.Name = "E";
            dodatek.Id = 2;

            controller.ViewData.ModelState.AddModelError("dodatek","Podana nazwa dodatku jest za krótka");
            var result = (ViewResult)controller.Edit(dodatek);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DisplayByIdExceptionMoq()
        {
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();

            context.Setup(x => x.FindDodatekById(2)).Returns((Dodatek)null);
            var controller = new DodatekController(context.Object);

            var result = controller.DisplayById(2) as ViewResult;

            Assert.AreEqual("Display", result.ViewName);
            var resultDodatek = (Dodatek)result.Model;
            Assert.AreEqual(typeof(Exception), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EditViewExceptionMoq()
        {
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindDodatekById(2)).Returns((Dodatek)null);
            var controller = new DodatekController(context.Object);
            var result = controller.Edit(25) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
            var resultDodatek = (Dodatek)result.Model;
            Assert.AreEqual(typeof(Exception), result.GetType());
        }
    }
}
