using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ASPizza.Controllers;
using ASPizza.Models;
using ASPizzaUnitTest.Doubles;
using ASPizza.ViewModels;
using System.Web.Mvc;

namespace ASPizzaUnitTest.Tests
{
    [TestClass]
    public class PizzaMoqTests
    {
        [TestMethod]
        public void ChceckViewNameAddMoq()
        {
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            var controller = new PizzaController(context.Object);
            var result = controller.Add() as ViewResult;
            Assert.AreEqual("Add", result.ViewName);
        }
        [TestMethod]
        public void ChceckTypeListInAll()
        {
            var ListPizza = new List<Pizza>();
            ListPizza.Add(new Pizza { Name = "Brokułowa", Price = 19.99M });
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.Pizzas).Returns(ListPizza.AsQueryable());
            var controller = new PizzaController(context.Object);

            var result = controller.All() as ViewResult;
            var model = ((ViewResult)result).Model as List<Pizza>;
            Assert.AreEqual(typeof(List<Pizza>), result.Model.GetType());
            Assert.IsTrue(model.Count == 1);
        }

        [TestMethod]
        public void TestDisplayAllMoqModel()
        {
            var ListPizza = new List<Pizza>();
            ListPizza.Add(new Pizza { Name = "Hawajska", Price = 19.99M });
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.Pizzas).Returns(ListPizza.AsQueryable());
            var controller = new PizzaController(context.Object);

            var result = controller.All() as ViewResult;
            var model = ((ViewResult)result).Model as List<Pizza>;
            Assert.IsTrue(model.Count == 1);
        }

        [TestMethod]
        public void TestDisplayPizzaByIdMoq()
        {
            Pizza pizza = new Pizza();
            pizza.Name = "Bekonowa";
            pizza.Price = 19.99M;
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindPizzaById(2)).Returns(pizza);
            var controller = new PizzaController(context.Object);

            var result = controller.DisplayById(2) as ViewResult;
            var resultPizza = (Pizza)result.Model;
            Assert.AreEqual("Bekonowa", resultPizza.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDisplayPizzaExceptionMoq()
        {
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindPizzaById(2)).Returns((Pizza)null);
            var controller = new PizzaController(context.Object);

            var result = controller.DisplayById(5) as ViewResult;
            var resultPizza = (Pizza)result.Model;
            Assert.AreEqual(typeof(Exception), result.GetType());
        }

        [TestMethod]
        public void ChceckTypeListInAllPizzasIfPriceless()
        {
            var ListPizza = new List<Pizza>();
            ListPizza.Add(new Pizza { Name = "Hawajska", Price = 19.99M });
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.PricelessPizzass()).Returns(ListPizza.AsQueryable());
            var controller = new PizzaController(context.Object);

            var result = controller.DisplayPriceless() as ViewResult;
            Assert.AreEqual(typeof(List<Pizza>), result.Model.GetType());
        }

        [TestMethod]
        public void TestDisplayPizzaByPeselNullMoq()
        {
            var ListPizza = new List<Pizza>();
            ListPizza.Add(new Pizza { Name = "Hawajska", Price = 19.99M });
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.PricelessPizzass()).Returns(ListPizza.AsQueryable());
            var controller = new PizzaController(context.Object);

            var result = controller.DisplayPriceless() as ViewResult;
            var modelPizzas = (IEnumerable<Pizza>)result.Model;
            Assert.AreEqual(1, modelPizzas.Count());
        }

        [TestMethod]
        public void TestDeleteViewMoq()
        {
            Pizza pizza = new Pizza();
            pizza.Name = "Bekonowa";
            pizza.Price = 19.99M;
            pizza.Id = 1;
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindPizzaById(2)).Returns(pizza);
            var controller = new PizzaController(context.Object);

            var result = controller.Delete(2) as ViewResult;
            var resultPizza = (Pizza)result.Model;
            Assert.AreEqual("Bekonowa", resultPizza.Name);
        }

        [TestMethod]
        public void TestDeletePizzaIsNotNullMoq()
        {
            Pizza pizza = new Pizza();
            pizza.Name = "Bekonowa";
            pizza.Price = 19.99M;
            pizza.Id = 1;
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindPizzaById(2)).Returns(pizza);
            var controller = new PizzaController(context.Object);

            var result = controller.Delete(2) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ChceckViewBackAdd()
        {
            var context = new FakePizzaSharingContext();
            var controller = new PizzaController(context);
            var result = controller.Add() as ViewResult;
            Assert.IsTrue(result.ViewBag.Napis == "Dodawanie nowej Pizzy");
        }

        [TestMethod]
        public void TestEditPizzaViewMoq()
        {
            Pizza pizza = new Pizza();
            pizza.Name = "Bekonowa";
            pizza.Price = 19.99M;
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindPizzaById(2)).Returns(pizza);
            var controller = new PizzaController(context.Object);

            var result = controller.Edit(2);
            ViewResult p = (ViewResult)controller.Edit(2);
            var view = p.ViewName;
            Assert.AreEqual("Edit", view);
        }

        [TestMethod]
        public void TestDeleteHttpMoq()
        {
            Pizza pizza = new Pizza();
            pizza.Name = "Bekonowa";
            pizza.Price = 19.99M;
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindPizzaById(2)).Returns(pizza);
            var controller = new PizzaController(context.Object);

            var result = controller.Delete(25);
            Assert.AreEqual(typeof(HttpNotFoundResult), result.GetType());
        }

        [TestMethod]
        public void TestEditHttpMoq()
        {
            Pizza pizza = new Pizza();
            pizza.Name = "Bekonowa";
            pizza.Price = 19.99M;
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindPizzaById(2)).Returns(pizza);
            var controller = new PizzaController(context.Object);

            var result = controller.Edit(25);
            Assert.AreEqual(typeof(HttpNotFoundResult), result.GetType());
        }

        [TestMethod]
        public void TestDeleteConfMoq()
        {
            Pizza pizza = new Pizza();
            pizza.Name = "Bekonowa";
            pizza.Price = 19.99M;
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindPizzaById(2)).Returns(pizza);
            context.Setup(s => s.SaveChanges()).Returns(0);
            var controller = new PizzaController(context.Object);
            var result = controller.DeleteConfirmed(2) as RedirectToRouteResult;

            Assert.AreEqual("All", result.RouteValues["Action"]);
            Assert.AreEqual("Pizza", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestEditPizzaMoq()
        {
            Pizza pizza = new Pizza();
            pizza.Name = "Carbonara";
            pizza.Price = 19.99M;
            pizza.Id = 5;
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindPizzaById(2)).Returns(pizza);
            context.Setup(x => x.SaveChanges()).Returns(0);
            var controller = new PizzaController(context.Object);
            pizza.Id = 2;
            var result = controller.Edit(pizza) as RedirectToRouteResult;

            Assert.AreEqual("All", result.RouteValues["Action"]);
            Assert.AreEqual("Pizza", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestEditPizzaModelNotValid()
        {
            Pizza pizza = new Pizza();
            pizza.Name = "PizzaTestowa";
            pizza.Price = 19.99M;
            pizza.Id = 5;
            Mock<IPizzaSharingContext> context = new Mock<IPizzaSharingContext>();
            context.Setup(x => x.FindPizzaById(2)).Returns(pizza);
            var controller = new PizzaController(context.Object);

            controller.ViewData.ModelState.AddModelError("Name", "Podaj nazwę");
            var result = (ViewResult)controller.Edit(pizza);
            Assert.AreEqual("Edit", result.ViewName);
        }
    }
}