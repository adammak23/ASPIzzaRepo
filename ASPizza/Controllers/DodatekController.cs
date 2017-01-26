using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ASPizza.Models;
using ASPizza.ViewModels;

public class DodatekController : Controller
{
    private ApplicationDbContext _context;

        public DodatekController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new DodatekFormViewModel();

            return View("DodatekForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
    public ActionResult Save(Dodatek Dodatek)
        {
            if (Dodatek.Id == 0)
                _context.Dodatki.Add(Dodatek);
            else
            {
                var DodatekInDb = _context.Dodatki.Single(c => c.Id == Dodatek.Id);
                DodatekInDb.Name = Dodatek.Name;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Pizza");
        }
    [Authorize(Roles = "Admin")]
    public ViewResult Index()
    {
        var Dodatki = _context.Dodatki;

        if (User.IsInRole("Admin"))
            return View("Index", Dodatki);


        return View("Index", Dodatki);
    }

    [Authorize(Roles = "Admin")]
    public ActionResult Delete(int id)
    {
        Dodatek dodatek = _context.Dodatki.Find(id);
        if (dodatek == null)
        {
            return HttpNotFound();
        }
        _context.Dodatki.Remove(dodatek);
        _context.SaveChanges();
        return RedirectToAction("Index", "Dodatek");
    }

}