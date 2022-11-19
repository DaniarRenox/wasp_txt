
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;


namespace dz2
{
    public class dz2
    {
       
        static void Main(string[] args)
        {
            List<car> cars= new List<car>();
            Dictionary<string, int> Repairbook = new Dictionary<string, int>
            {
                { "breaks", 2005 }
            };
            PassengerCar car1 = new PassengerCar("BMW", "1234", "2000", 4, Repairbook);
            Dictionary<string, int> Cargo = new Dictionary<string, int>
            {
                {"Chebureki",2000 }
            };
            Truck truck1 = new Truck("Volvo", "2350925925", "2010", 5000, "Avarev Dzhamshoot Yeldibichtinhondorbirdinkanimovich", Cargo);
            cars.Add(car1);
            cars.Add(truck1);
            Autopark MyAutos = new Autopark("MyAutos", cars);
            Console.WriteLine(MyAutos.ToString());
        }
    }
}