using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPizza.Models;

namespace ASPizza.ViewModels
{
    public class PizzaFormViewModel
    {
        public IEnumerable<Dodatek> Dodatki { get; set; }
        public Pizza Pizza { get; set; }
    }
}

