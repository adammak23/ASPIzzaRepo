using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPizza.Models;
using ASPizza.ViewModels;
using ASPizza.Controllers;

[AllowAnonymous]
public class PizzaController : Controller
{
    private IPizzaSharingContext _context;

    public PizzaController()
    {
        _context = new PizzaSharingContext();
    }

    public PizzaController(IPizzaSharingContext Context)
    {
        _context = Context;
    }
    [HandleError(View = "Error")]
    [ValueReporter]
    public ActionResult All()
    {
        List<Pizza> pizzaAll = _context.Pizzas.ToList();
        return View(pizzaAll);
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
    public ActionResult DeleteConfirmed(int id)
    {
        Pizza pizza = _context.FindPizzaById(id);
        _context.Delete<Pizza>(pizza);
        _context.SaveChanges();
        return RedirectToAction("All", "Pizza");
    }

    public ActionResult DisplayPriceless()
    {
        List<Pizza> Pricelesspizzas = _context.PricelessPizzass().ToList();
        return View("All", Pricelesspizzas);
    }

    public ActionResult Add()
    {
        ViewBag.Napis = "Dodawanie nowej Pizzy";
        return View("Add");
    }

    [HttpPost]
    public ActionResult Add(PizzaFormViewModel PizzaFormViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View("Add", PizzaFormViewModel);
        }
        else
        {
            Dodatek dodatek = new Dodatek();
            dodatek.Id = 1;
            dodatek.Name = "ser";
            _context.Add<Dodatek>(dodatek);

            Pizza pizza = new Pizza();
            pizza.Id = 1;
            pizza.Name = "Carbonara";
            pizza.Price = 19.99M;
            pizza.DodatekId=1;
            pizza.Dodatek = dodatek;
            _context.Add<Pizza>(pizza);

            _context.SaveChanges();
            return RedirectToAction("All", "Pizza");
        }
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
            _context.Add(pizza);
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

    [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
    public ActionResult DisplayById(int id)
    {
        Pizza pizza = _context.FindPizzaById(id);
        if (pizza == null)
        {
            throw new Exception();
        }

        return View("Display", pizza);
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

    /*   [Authorize(Roles = "Admin")]
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
    */
    public ActionResult Edit(int id)
    {
        Pizza pizza = _context.FindPizzaById(id);
        if (pizza == null)
        {
            return HttpNotFound();
        }
        return View("Edit", pizza);
    }

    [HttpPost]
    public ActionResult Edit(Pizza pizza)
    {
        if (!ModelState.IsValid)
        {
            return View("Edit", pizza);
        }
        else
        {
            Pizza editPizza = _context.FindPizzaById(pizza.Id);
            editPizza.Name = pizza.Name;
            editPizza.Id = pizza.Id;
            editPizza.Price = pizza.Price;
            _context.SaveChanges();
            return RedirectToAction("All", "Pizza");
        }
    }

    //   [Authorize(Roles = "Admin")]
    public ActionResult Delete(int id)
    {
        Pizza pizza = _context.FindPizzaById(id);
        if (pizza == null)
        {
            return HttpNotFound();
        }
        return View("Delete", pizza);
    }
    public ActionResult Delete2(int id)
    {
        Pizza pizza = _context.FindPizzaById(id);
        if (pizza == null)
        {
            return HttpNotFound();
        }
        _context.Delete(pizza);
        _context.SaveChanges();
        return RedirectToAction("Index", "Pizza");
    }
}
