using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace ASPizza.Models
{
    public interface IPizzaSharingContext
    {
        IQueryable<Pizza> Pizzas { get; }
        IQueryable<Pizza> PricelessPizzass();
        IQueryable<Dodatek> Dodatki { get; }
        T Add<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
        int SaveChanges();
        Pizza FindPizzaById(int id);
        Dodatek FindDodatekById(int id);
    }
}