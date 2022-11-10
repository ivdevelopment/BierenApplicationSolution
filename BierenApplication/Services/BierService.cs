using BierenApplication.Controllers;
using BierenApplication.Models;
using System;

namespace BierenApplication.Services
{
    public class BierService
    {
        
        private Dictionary<int, Bier> bieren = new Dictionary<int, Bier>();
        public BierService()
        {
            bieren[1] = new Bier
            {
                Id = 1,
                Naam = "Romy pils",
                Alcohol = 4.5F,
                Prijs = 0.70m
            };
            bieren[2] = new Bier
            {
                Id = 2,
                Naam = "Leffe blond",
                Alcohol = 2.5F,
                Prijs = 1.15m
            };
            bieren[3] = new Bier
            {
                Id = 3,
                Naam = "Rodenbach",
                Alcohol = 3.5F,
                Prijs = 0.85m
            };
            bieren[4] = new Bier
            {
                Id = 4,
                Naam = "Liefmans goudenband",
                Alcohol = 6F,
                Prijs = 0.90m
            };
            bieren[5] = new Bier
            {
                Id = 5,
                Naam = "Duvel",
                Alcohol = 7F,
                Prijs = 1.20m
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

        public void Prijsverhoging(decimal percentage)
        {
            foreach (var bier in bieren.Values)
            {
                bier.Prijs *= (1m + percentage/100);
            }
        }

        public List<Bier> VanTotAlcohol(float? van, float? tot)
        {
            return (from bier in bieren.Values
                    where bier.Alcohol >= van && bier.Alcohol <= tot
                    orderby bier.Alcohol
                    select bier).ToList();
        }

        public void Add(Bier b)
        {
            b.Id = bieren.Keys.Max() + 1;
            bieren.Add(b.Id, b);
        }
    }
}
