using BierenApplication.Models;
using BierenApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace BierenApplication.Controllers
{
    public class BierController : Controller
    {
        private readonly BierService _bierService;
        public BierController(BierService bierService)
        {
            _bierService = bierService;
        }

        public IActionResult Index()
        {
            return View(_bierService.FindAll());
        }

        public IActionResult Verwijderen(int Id)
        {
            var bier = _bierService.Read(Id);
            return View(bier);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var bier = _bierService.Read(Id);
            this.TempData["bier"] = JsonConvert.SerializeObject(bier);
            _bierService.Delete(Id);
            return RedirectToAction(nameof(Verwijderd));
        }
        
        public IActionResult Verwijderd()
        {
            var verwijderBier = (string?)this.TempData["bier"];
            if (verwijderBier != null)
                return View(JsonConvert.DeserializeObject<Bier>(verwijderBier));
            else
                return RedirectToAction("index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Prijsverhoging()
        {
           _bierService.Prijsverhoging(5m);
            return RedirectToAction(nameof(Index), _bierService.FindAll());
        }

        [HttpGet]
        public IActionResult VanTotAlcohol()
        {
            var vanTotAlcoholViewModel = new VanTotAlcoholViewModel();
            return View(vanTotAlcoholViewModel);
        }

        [HttpGet]
        public IActionResult VanTotAlcoholResultaat(VanTotAlcoholViewModel vanTotAlcoholViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var lijst = _bierService.VanTotAlcohol(vanTotAlcoholViewModel.VanAlcohol, vanTotAlcoholViewModel.TotAlcohol);
                if (lijst.Count <= 3)
                    // geen extra probleem
                    vanTotAlcoholViewModel.Bieren = lijst;
                else
                    // wel een probleem
                    this.ModelState.AddModelError("", "Te veel resultaten");
            }
            return View(nameof(VanTotAlcohol), vanTotAlcoholViewModel);
        }

        [HttpGet]
        public IActionResult Toevoegen()
        {
            var bier = new Bier();
            return View(bier);
        }

        [HttpPost]
        public IActionResult Toevoegen(Bier b)
        {
            if (this.ModelState.IsValid)
            {
                _bierService.Add(b);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(b);
            }
        }
    }
}
