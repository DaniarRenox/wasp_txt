using mainfile;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Programm
{
    public class Dz2
    {
        static void Main(string[] args)
        {
            Store store = new Store("Chernobog", "Novye Cheremuchki");
            Audio audio1 = new Audio("Rick Astley", "IDK", 1, "RickRoll", "rolling u");
            Audio audio2 = new Audio("Rick Astley", "IDK", 2, "RickRoll2", "rolling u2");
            DVD disk1 = new DVD("Prod1","Comp1",30,"RollingGuys","rolling u");
            DVD disk2 = new DVD("Prod2", "Comp2", 128, "RollingGirls", "rolling u2");
            store._Audios = store + audio1;
            store._Audios = store + audio2;
            store._Dvds = store + disk1;
            store._Dvds = store + disk2;
            store.ToString();
            disk1.Burn("ProdBurn", "CompBurn", "60", "RollingBurn", "rolling Burn");
            foreach (DVD dvd in store._Dvds)
            {
                Console.WriteLine($"name of disk is {dvd._name}, size ={dvd.DiskSize}");
            }
        }
    }
}