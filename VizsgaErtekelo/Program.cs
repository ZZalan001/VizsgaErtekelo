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
            FeltoltFeladatok("teszt1.txt",1);
            string[] valasz1 = { "a", "b", "c", "a", "b", "c", "a", "b", "c", "a" };
            if (tesztek[0].Sikeres(valasz1))
            {
                Console.WriteLine("Sikeres vizsga!");
            }
            else
            {
                Console.WriteLine("Sikertelen vizsga!");
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

        static void FeltoltFeladatok(string fileName, int id)
        {
            int index = 0;
            while (index < tesztek.Count && !(tesztek[index].Id == id))
            {
                index++;
            }
            if (index < tesztek.Count)
            {
                string[] sorok = File.ReadAllLines(fileName);
                for (global::System.Int32 i = 0; i < sorok.Length; i++)
                {
                    tesztek[index].Feladatok[i] = new Feladat()
                    {
                        Megoldas = sorok[i].Split(';')[0],
                        Pontertek = int.Parse(sorok[i].Split(';')[1])
                    };
                }
            }
            else
            {
                Console.WriteLine("Nincs megfelelő azonosítójú teszt!");
            }
            

        }
    }
}
