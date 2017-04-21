using ASPizza.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ASPizza.Controllers;

namespace ASPizzaUnitTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestAbout()
        {
            HomeController controllerUnderTest = new HomeController();
            var result = controllerUnderTest.About() as ViewResult;
            Assert.AreEqual("Your application description page.", result.ViewData["Message"]);
        }
        [TestMethod]
        public void TestContact()
        {
            HomeController controllerUnderTest = new HomeController();
            var result = controllerUnderTest.Contact() as ViewResult;
            Assert.AreEqual("Your contact page.", result.ViewData["Message"]);
        }
        [TestMethod]
        public void TestIndex()
        {
            HomeController controllerUnderTest = new HomeController();
            var result = controllerUnderTest.Index() as ViewResult;
            Assert.AreEqual("Main page.", result.ViewData["Message"]);
        }
    }
}