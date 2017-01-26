using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ASPizza.Models.Validators;

namespace ASPizza.Models
{
    public class Dodatek
    {

        public int Id { get; set; }
        [DodatekStringValidator]
        public string Name { get; set; }
    }
}