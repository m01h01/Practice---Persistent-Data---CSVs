using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice___Persistent_Data___CSVs
{
    public class Car
    {
        string _make;
        string _model;
        string _year;
        int _mileage;

        //a defualt MUST created for loading CSV file
        public Car()
        { }
        public Car(string make, string model, string year, int mileage)
        {
            _make = make;
            _model = model;
            _year = year;
            _mileage = mileage;
        }

        public string Make { get => _make; set => _make = value; }
        public string Model { get => _model; set => _model = value; }
        public string Year { get => _year; set => _year = value; }
        public int Mileage { get => _mileage; set => _mileage = value; }


        public override string ToString()
        {
            return $"{_year} {_make} {_model} -" +
                $" Mileage {_mileage}";
        }

    }//class
}//namespace
