using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveWellApp.BusinessLogic
{
    public class Car // creating car class
    {
        //all field variables for this class
        string _vin;
        string _carMake;
        CarType _type;
        float _price;
        int _modelYear;
        
        public string Vin // accessor and mutator for vin
        {
            get{ return _vin; }
            set 
            { if (string.IsNullOrEmpty(value) || !value.All(char.IsLetterOrDigit) || value.Length != 17)
                    throw new Exception("Vin can only be string containing 17 alphanumeric characters.");
                    _vin = value;       
            }

        }
        public string CarMake// accessor and mutator for car make
        {
            get => _carMake;
            set
            {if (string.IsNullOrEmpty(value))
                    throw new Exception("Car amke cannot be empty");
                _carMake = value;
            }
        }

        public CarType CarType// accessor and mutator for car type enum
        {
            get => _type;
            set
            {
                _type = value;
            }
        }

        public float Price// accessor and mutator for price
        {
            get => _price; 
            set
            {if (value <= 0)
                    throw new Exception("Price cannot be negative and zero");
                _price = value;
            }
        }

        public int ModelYear// accessor and mutator for model year
        {
            get => _modelYear; 
            set
            {if (value < 2000 || value > DateTime.Now.Year)
                    throw new Exception("Model Year is not in valid range.");
                _modelYear = value;
            }
        }
        public virtual float NetPrice // computed property calculating price
        {
            get => Price + (Price * 0.13f);
        }

        public Car(string vin,string carMake,CarType type,float price,int modelYear) // initializor for Car class
        {
            Vin = vin;
            CarMake = carMake;
            CarType = type;
            Price = price;
            ModelYear = modelYear;
            
        }





    }


}
