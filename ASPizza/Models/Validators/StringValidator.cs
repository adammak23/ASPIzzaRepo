using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPizza.Models.Validators
{
    public class StringValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var pizza = (Pizza)validationContext.ObjectInstance;

            if (string.IsNullOrWhiteSpace(pizza.Name) || string.IsNullOrEmpty(pizza.Name))
                return new ValidationResult("Serio chcesz stworzyć pizzę bez nazwy?");

            if (pizza.Name.Length>=2 && pizza.Name.Length<=30)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Nazwa powinna mieć od 3 do 30 znaków!");
            }
        }
    }

    public class Cena : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var pizza = (Pizza)validationContext.ObjectInstance;

            if (pizza.Price >= 5 && pizza.Price <= 100)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Cena może wynosić od 5 do 100zł!");
            }
        }
    }
    public class DodatekStringValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dodatek = (Dodatek)validationContext.ObjectInstance;

            if (string.IsNullOrWhiteSpace(dodatek.Name) || string.IsNullOrEmpty(dodatek.Name))
                return new ValidationResult("Serio chcesz stworzyć dodatek bez nazwy?");

            if (dodatek.Name.Length >= 2 && dodatek.Name.Length <= 30)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Nazwa powinna mieć od 3 do 30 znaków!");
            }
        }
    }
}