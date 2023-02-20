using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveWellApp.BusinessLogic
{
    public class UsedCar : Car
    {
        int _kiloMeters;

        public int KiloMeters
        {
            get { return _kiloMeters; }
            set {if (value <= 0)
                    throw new ArgumentOutOfRangeException("Kilometers can not be negative or zero");
                _kiloMeters = value;}
        }
        public float Depreciation
        {
            get 
            { float depericiation =( Price * (DateTime.Now.Year - ModelYear) * 0.1f ) + (Price * (_kiloMeters / 10000) * 0.009f);
              return depericiation;
            }
        }
        public override float NetPrice
        {
            get => Price - Depreciation * 1.13f; 
        }

        public UsedCar(int kiloMeters,string vin ,string carMake, CarType type, float price ,int modelYear) : base(vin,carMake,type,price,modelYear)
        {
            _kiloMeters = kiloMeters;
            
        }
    }
    }

