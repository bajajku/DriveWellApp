using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveWellApp.BusinessLogic
{
    public class Car
    {
        string _vin;
        string _carMake;
        CarType _type;
        float _price;
        int _modelYear;
        
        public string Vin
        {
            get{ return _vin; }
            set 
            { if (string.IsNullOrEmpty(value) || !value.All(char.IsLetterOrDigit) || value.Length == 17)
                    throw new Exception("Vin can only be string containing 17 alphanumeric characters.");
                    _vin = value;       
            }

        }
        public string CarMake
        {
            get => _carMake;
            set
            {if (string.IsNullOrEmpty(value))
                    throw new Exception("Car amke cannot be empty");
                _carMake = value;
            }
        }

        public CarType CarType
        {
            get => _type;
            set
            {
                _type = value;
            }
        }

        public float Price
        {
            get => _price; 
            set
            {if (value <= 0)
                    throw new Exception("Price cannot be negative and zero");
                _price = value;
            }
        }

        public int ModelYear
        {
            get => _modelYear; 
            set
            {if (value < 2000 || value > DateTime.Now.Year)
                    throw new Exception("Model Year is not in valid range.");
                _modelYear = value;
            }
        }
        public virtual float NetPrice
        {
            get => Price + (Price * 0.13f);
        }

        public Car(string vin,string carMake,CarType type,float price,int modelYear)
        {
            Vin = vin;
            CarMake = carMake;
            CarType = type;
            Price = price;
            ModelYear = modelYear;
            
        }





    }


}
