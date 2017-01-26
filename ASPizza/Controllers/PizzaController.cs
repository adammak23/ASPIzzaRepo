using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPizza.Models;
using ASPizza.ViewModels;


public class PizzaController : Controller
{
    private ApplicationDbContext _context;

    public PizzaController()
    {
        _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
    }

//    [Authorize(Roles = "Admin")]
    public ActionResult New()
    {
        var dodatki = _context.Dodatki.ToList();
        var viewModel = new PizzaFormViewModel
        {
            Pizza = new Pizza(),
            Dodatki = dodatki
        };

        return View("PizzaForm", viewModel);
    }



    [HttpPost]
//    [Authorize(Roles = "Admin")]
    public ActionResult Save(Pizza pizza)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new PizzaFormViewModel()
            {
                Pizza = pizza,
                Dodatki = _context.Dodatki.ToList()
            };

            return View("PizzaForm", viewModel);
        }

        if (pizza.Id == 0)
            _context.Pizzas.Add(pizza);
        else
        {
            var customerInDb = _context.Pizzas.Single(c => c.Id == pizza.Id);
            customerInDb.Name = pizza.Name;
            customerInDb.Price = pizza.Price;
            customerInDb.DodatekId = pizza.DodatekId;
        }

        _context.SaveChanges();

        return RedirectToAction("Index", "Pizza");
    }

    public ViewResult Index()
    {
        var Pizzas = _context.Pizzas.Include(c => c.Dodatek).ToList();

        if (User.IsInRole("Admin"))
            return View("AdminIndex", Pizzas);


        return View("Index", Pizzas);
    }

    public ActionResult Details(int id)
    {
        var Pizza = _context.Pizzas.Include(c => c.Dodatek).SingleOrDefault(c => c.Id == id);

        if (Pizza == null)
            return HttpNotFound();

        return View(Pizza);
    }

    //   [Authorize(Roles = "Admin")]
    public ActionResult Edit(int id)
    {
        var Pizza = _context.Pizzas.SingleOrDefault(c => c.Id == id);

        if (Pizza == null)
            return HttpNotFound();

        var viewModel = new PizzaFormViewModel
        {
            Pizza = Pizza,
            Dodatki = _context.Dodatki.ToList()
        };

        return View("PizzaForm", viewModel);
    }
 //   [Authorize(Roles = "Admin")]
    public ActionResult Delete(int id)
    {
        Pizza pizza = _context.Pizzas.Find(id);
        if (pizza == null)
        {
            return HttpNotFound();
        }
        _context.Pizzas.Remove(pizza);
        _context.SaveChanges();
        return RedirectToAction("Index", "Pizza");
    }
}
