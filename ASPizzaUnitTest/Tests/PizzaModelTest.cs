using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPizza.Models;
using ASPizza.ViewModels;

namespace ASPizzaUnitTest
{
    [TestClass]
    public class PizzaModelTest
    {
        private ApplicationDbContext _context;
        [TestMethod]
        public void CorrectPizzaModel()
        {
            _context = new ApplicationDbContext();
            var pizza = new Pizza()
            {
                Id = 4,
                Name = "CarbonAra",
                DodatekId = 5
            };

        }
        [TestMethod]
        public void NoNamePizzaModelTest()
        {
            var pizza = new Pizza()
            {
                Name = null
            };
            var result = TestModelHelper.Validate(pizza);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Podaj nazwę", result[0].ErrorMessage);
        }
    }
}


