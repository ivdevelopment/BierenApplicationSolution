using BierenApplication.Models;
using BierenApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            return Redirect("~/bier/verwijderd");
        }
        
        public IActionResult Verwijderd()
        {
            var verwijderBier = (string?)this.TempData["bier"];
            if (verwijderBier != null)
                return View(JsonConvert.DeserializeObject<Bier>(verwijderBier));
            else
                return RedirectToAction("index");
        }
    }
}
