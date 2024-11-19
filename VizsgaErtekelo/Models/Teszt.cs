using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Hatar = 30.0;
            int osztalyzat = 0;

            int osszpont = 0;
            for (int i = 0; i < valaszok.Length; i++)
            {
                if (valaszok[i] == Feladatok[i].Megoldas)
                {
                    osszpont += Feladatok[i].Pontertek;
                }
            }

            if (osszpont >= Hatar * 0.8)
            {
                osztalyzat = 5;
            }
            else if(osszpont >= Hatar * 0.6 && osszpont < Hatar * 0.8)
            {
                osztalyzat = 4;
            }
            else if (osszpont >= Hatar * 0.4 && osszpont < Hatar * 0.6)
            {
                osztalyzat = 3;
            }
            else if (osszpont >= Hatar * 0.2 && osszpont < Hatar * 0.4)
            {
                osztalyzat = 2;
            }
            else 
            {
                osztalyzat = 1;
            }
            return osztalyzat;
        }
    }
}
