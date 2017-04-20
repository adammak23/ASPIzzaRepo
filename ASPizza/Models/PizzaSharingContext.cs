using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPizza.Models
{
    public class PizzaSharingContext : DbContext, IPizzaSharingContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Dodatek> Dodatki { get; set; }

    IQueryable<Pizza> IPizzaSharingContext.Pizzas
    {
        get { return Pizzas; }
    }

    IQueryable<Dodatek> IPizzaSharingContext.Dodatki
    {
        get { return Dodatki; }
    }


    IQueryable<Pizza> IPizzaSharingContext.PricelessPizzass()
    {
        IQueryable<Pizza> pizzas = Pizzas.Where(p => p.Price == 0);
        return pizzas;
    }
    int IPizzaSharingContext.SaveChanges()
    {
        return SaveChanges();
    }
    T IPizzaSharingContext.Add<T>(T entity)
    {
        return Set<T>().Add(entity);
    }
    T IPizzaSharingContext.Delete<T>(T entity)
    {
        return Set<T>().Remove(entity);
    }
    Pizza IPizzaSharingContext.FindPizzaById(int id)
    {
        Pizza pizza = (from p in Set<Pizza>()
                         where p.Id == id
                         select p).FirstOrDefault();
        return pizza;
    }
    Dodatek IPizzaSharingContext.FindDodatekById(int id)
    {
        Dodatek dodatek = (from a in Set<Dodatek>()
                       where a.Id == id
                       select a).FirstOrDefault();
        return dodatek;
    }
}
}