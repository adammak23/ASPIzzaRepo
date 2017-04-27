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
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Podana nazwa dodatku jest za krótka")]
        [RegularExpression(@"^[a-zA-ZĄĆĘŁŃÓŚŹŻąćęłńóżź \\s \\-]*$", ErrorMessage = "Zła nazwa dodatku")]
        public string Name { get; set; }
    }
}