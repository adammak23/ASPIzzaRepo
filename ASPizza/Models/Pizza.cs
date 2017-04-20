using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ASPizza.Models.Validators;

namespace ASPizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę")]
        public string Name { get; set; }

        [Cena]
        public Decimal Price { get; set; }

        public Dodatek Dodatek { get; set; }

        public int DodatekId { get; set; }
    }
}