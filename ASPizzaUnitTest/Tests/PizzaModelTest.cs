using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPizza.Models;

namespace ASPizzaUnitTest
{
    class PizzaModelTest
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
    }
}


