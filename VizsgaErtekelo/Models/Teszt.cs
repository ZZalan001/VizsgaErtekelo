using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VizsgaErtekelo.Interfaces;

namespace VizsgaErtekelo.Models
{
    internal class Teszt : Vizsga, IOsztalyozhato
    {
        public Feladat[] Feladatok {  get; set; }
        public Teszt() { }
        public Teszt(int id, string megnevezes, int feladatszam, int pontszam = 0)
        {
            Id = id;
            Megnevezes = megnevezes;
            Pontszam = pontszam;
            Feladatok = Feladatok;
        }
        public Teszt(string sor)
        {
            string[] bontas = sor.Split(';');
            Id = int.Parse(bontas[0]);
            Megnevezes = bontas[1];
            Pontszam = int.Parse(bontas[2]);
            Feladatok = new Feladat[int.Parse(bontas[
                3])];
        }
        public bool Sikeres()
        {
            throw new NotImplementedException();
        }

        public int Osztalyzat()
        {
            throw new NotImplementedException();
        }
    }
}
