using BierenApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BierenApplication.Controllers
{
    public class BierController : Controller
    {
        public IActionResult Index()
        {
            List<Bier> bieren = new() { new Bier { Id = 1, Naam = "Romy Pils", Alcohol = 5f }, new Bier { Id = 2, Naam = "Kasteelbier", Alcohol = 12f }, new Bier { Id = 3, Naam = "Maes Radler", Alcohol = 0f } };
            return View(bieren);
        }
    }
}
