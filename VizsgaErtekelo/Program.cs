using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VizsgaErtekelo.Models;

namespace VizsgaErtekelo
{
    internal class Program
    {
        static List<Teszt> tesztek = new List<Teszt>();
        static void Main(string[] args)
        {
            int darabszam = BeolvasTesztek("tesztek.txt");
            if(darabszam > 0) 
            { 
                Console.WriteLine($"A beolvasás sikeres! {darabszam} db tesztet rögzítettünk!"); 
            }
            else 
            { 
                Console.WriteLine("A beolvasás nem sikerült!"); 
            }

            Console.ReadLine();
        }
        static int BeolvasTesztek(string fileName)
        {
            try
            {
                string[] sorok = File.ReadAllLines(fileName);
                for (int i = 0; i < sorok.Length; i++)
                {
                    tesztek.Add(new Teszt(sorok[i]));
                }
                return sorok.Length;
            }
            catch (FileNotFoundException fnfex)
            {
                Console.WriteLine(fnfex.Message);
                return -1;
            }
            catch (FormatException fex)
            {
                Console.WriteLine(fex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            
        }
    }
}
