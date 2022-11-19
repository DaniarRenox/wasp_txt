using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    public class car
    {
        protected string _brand;
        protected string _power;
        protected string _year;


        public car(string brand, string power, string year)
        {
            this._brand = brand;
            this._power = power;
            this._year = year;
        }

        public override string ToString()
        {
            return $"brand is:{_brand}\npower is:{_power}\nyear of production is:{_year}\n";
        }

    }
    public class PassengerCar : car
    {
        protected int _Passengers;
        protected Dictionary<string, int> _RepairBook = new Dictionary<string, int>();
        public PassengerCar(string brand, string power, string year, int Passengers, Dictionary<string, int> Repairbook) : base(brand, power, year) 
        {
            this._Passengers = Passengers;
            this._RepairBook = Repairbook;
        }
        
        public void AddToBook(string name,int year)
        {
            _RepairBook.Add(name, year);
        }
        public int GetYear(string name)
        {
            return _RepairBook[name];
        }
        public void PrintTheBook()
        {
            foreach(string name in _RepairBook.Keys)
            {
                Console.WriteLine($"{name} ::: {_RepairBook[name]}");
            }
        }
        

        public override string ToString()
        {
            return $"brand is:{_brand}\npower is:{_power}\nyear of production is:{_year}\nthe amount of passengers is:{_Passengers}\n";
        }
    }
    public class Truck : car
    {
        int _MaxWeight;
        string _DriverInit;
        Dictionary<string, int> _CurrentCargo;

        public Truck(string brand, string power, string year, int MaxWeight, string DriverInit, Dictionary<string,int> CurrentCargo) :base(brand, power, year)
        {
            this._MaxWeight = MaxWeight;
            this._DriverInit=DriverInit;
            this._CurrentCargo = CurrentCargo;
        }
        public void DriverChange(string NewName)
        {
            _DriverInit= NewName;
        }
        public void ChangeCargo(string NewCargoName,int NewCargoWeight)
        {
            _CurrentCargo.Add(NewCargoName, NewCargoWeight);
        }
        public void ChangeCargo()
        {
            _CurrentCargo.Clear();
        }
        public void PrintTheCargo()
        {
            foreach(string CargoName in _CurrentCargo.Keys)
            {
                Console.WriteLine($"{CargoName}:::{_CurrentCargo[CargoName]}");
            }
        }
        public override string ToString()
        {
            return $"brand is:{_brand}\npower is:{_power}\nyear of production is:{_year}\nMax weight is:{_MaxWeight}\nDriver is:{_DriverInit}\n";
        }
    }
    public class Autopark
    {
        protected string _AutoparkName;
        protected List<car> _Carlist;
        public Autopark(string AutoparkName, List<car> cars)
        {
            this._AutoparkName= AutoparkName;
            this._Carlist = cars;
        }
        public override string ToString()
        {
            string boof = $"Autopark name is {_AutoparkName}\n";
            foreach (car car in _Carlist)
            {
                boof += car.ToString();
            }
            return boof;
        }
    }
}
