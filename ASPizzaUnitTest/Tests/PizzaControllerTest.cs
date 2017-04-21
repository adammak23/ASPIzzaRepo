using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPizza.Controllers;
using ASPizza.Models;
using ASPizzaUnitTest.Doubles;
using ASPizza.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ASPizzaUmitTest.Tests
{
    [TestClass]
    public class PizzaControllerTest
    {
        [TestMethod]
        public void ChceckViewNameAdd()
        {
            var context = new FakePizzaSharingContext();
            var controller = new PizzaController(context);
            var result = controller.Add() as ViewResult;
            Assert.AreEqual("Add", result.ViewName);
        }

        [TestMethod]
        public void TestDisplayAll()
        {
            var context = new FakePizzaSharingContext();
            context.Pizzas = new[] {
                 new Pizza{ Id = 1, Name = "pizza1", Price = 19.99m, DodatekId=1},
                 new Pizza{ Id = 2, Name = "pizza2", Price = 10, DodatekId=2},
                 new Pizza{ Id = 3, Name = "pizza3", Price = 15, DodatekId=2}
             }.AsQueryable();
            var controller = new PizzaController(context);
            var result = controller.All() as ViewResult;
            var modelPizza = (IEnumerable<Pizza>)result.Model;
            Assert.AreEqual(3, modelPizza.Count());
        }
        [TestMethod]
        public void TestDisplayPizzasWithoutPrice()
        {
            var context = new FakePizzaSharingContext();
            context.Pizzas = new[] {
                 new Pizza{ Id = 1, Name = "pizza1", Price = 19.99m, DodatekId=1},
                 new Pizza{ Id = 2, Name = "pizza2", Price = 0, DodatekId=2},
                 new Pizza{ Id = 3, Name = "pizza3", DodatekId=2}

             }.AsQueryable();
            var controller = new PizzaController(context);
            var result = controller.DisplayPriceless() as ViewResult;
            var modelPizza = (IEnumerable<Pizza>)result.Model;
            Assert.AreEqual(2, modelPizza.Count());
        }
        [TestMethod]
        public void TestDeleteView()
        {
            var context = new FakePizzaSharingContext();
            context.Pizzas = new[] {
                 new Pizza{ Id = 1, Name = "pizza1", Price = 19.99m, DodatekId=1},
                 new Pizza{ Id = 2, Name = "pizza2", Price = 10, DodatekId=2},
                 new Pizza{ Id = 3, Name = "pizza3", Price = 15, DodatekId=2}

            }.AsQueryable();
            var controller = new PizzaController(context);
            var result = controller.Delete(2) as ViewResult;
            var modelPizza = (Pizza)result.Model;
            Assert.AreEqual(10, modelPizza.Price);
        }
    }
}
