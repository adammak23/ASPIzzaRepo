using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ASPizza.Models;
using ASPizza.ViewModels;

[AllowAnonymous]
public class DodatekController : Controller
{
    private IPizzaSharingContext _context;

        public DodatekController()
        {
            _context = new PizzaSharingContext();
        }
        public DodatekController(IPizzaSharingContext Context)
        {
            _context = Context;
        }

    /*      protected override void Dispose(bool disposing)
          {
              _context.Dispose();
          }
  */
    public ActionResult New()
        {
            var viewModel = new DodatekFormViewModel();

            return View("DodatekForm", viewModel);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
    public ActionResult Save(Dodatek Dodatek)
        {
        if (Dodatek.Id == 0)
            _context.Add(Dodatek);
        else
        {
            var DodatekInDb = _context.Dodatki.Single(c => c.Id == Dodatek.Id);
            DodatekInDb.Name = Dodatek.Name;

        }

            _context.SaveChanges();

            return RedirectToAction("Index", "Pizza");
        }
    //[Authorize(Roles = "Admin")]
    public ViewResult Index()
    {
        var Dodatki = _context.Dodatki;

        if (User.IsInRole("Admin"))
            return View("Index", Dodatki);


        return View("Index", Dodatki);
    }

    //[Authorize(Roles = "Admin")]
    public ActionResult Delete(int id)
    {
        Dodatek dodatek = _context.FindDodatekById(id);
        if (dodatek == null)
        {
            return HttpNotFound();
        }
        _context.Delete(dodatek);
        _context.SaveChanges();
        return RedirectToAction("Index", "Dodatek");
    }

    [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
    public ActionResult DisplayById(int id)
    {
        Dodatek dodatek = _context.FindDodatekById(id);

        if (dodatek == null)
        {
            throw new Exception();
        }
        return View("Display", dodatek);
    }

    [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
    public ActionResult Edit(int id)
    {
        Dodatek dodatek = _context.FindDodatekById(id);
        if (dodatek == null)
        {
            throw new Exception();
        }
        return View("Edit", dodatek);
    }

    [HttpPost]
    public ActionResult Edit(Dodatek dodatek)
    {
        if (!ModelState.IsValid)
        {
            return View("Edit", dodatek);
        }
        Dodatek editDodatek = _context.FindDodatekById(dodatek.Id);
        editDodatek.Name = dodatek.Name;
        _context.SaveChanges();
        return RedirectToAction("All", "Pizza");
    }
}