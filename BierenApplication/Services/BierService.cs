using BierenApplication.Controllers;
using BierenApplication.Models;

namespace BierenApplication.Services
{
    public class BierService
    {
        
        private Dictionary<int, Bier> bieren = new Dictionary<int, Bier>();
        public BierService()
        {
            bieren[1] = new Bier()
            {
                Id = 1,
                Naam = "Romy Pils",
                Alcohol = 5f
            };
            bieren[2] = new Bier()
            {
                Id = 2,
                Naam = "Kasteelbier",
                Alcohol = 12f
            };
            bieren[3] = new Bier()
            {
                Id = 3,
                Naam = "Maes Radler",
                Alcohol = 0f
            };
        }

        public List<Bier> FindAll()
        {
            // levert enkel de values op van de dictionary
            return bieren.Values.ToList();
        }

        public Bier Read(int id)
        {
            return bieren[id];
        }
        public void Delete(int id)
        {
            bieren.Remove(id);
        }
    }
}
