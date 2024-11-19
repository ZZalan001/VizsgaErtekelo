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
        public double Hatar {  get; set; } //Akkor sikeres, ha ennyi %-ot elér
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
            Feladatok = new Feladat[int.Parse(bontas[3])];
        }
        public void BetoltFeladat(string fileName)
        {

        }
        public bool Sikeres(string[] valaszok)
        {
            Hatar = 60.0;
            int osszpont = 0;
            for (int i = 0; i < valaszok.Length; i++)
            {
                if (valaszok[i] == Feladatok[i].Megoldas)
                {
                    osszpont += Feladatok[i].Pontertek;
                }
            }
            return osszpont >= Pontszam * Hatar / 100;
        }

        public int Osztalyzat(string[] valaszok)
        {
            throw new NotImplementedException();
        }
    }
}
