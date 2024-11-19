using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VizsgaErtekelo.Interfaces;

namespace VizsgaErtekelo.Models
{
    internal class Vizsga
    {
        public int Id { get; set; }
        public string Megnevezes { get; set; }
        public int Pontszam {  get; set; }

        
    }
}
