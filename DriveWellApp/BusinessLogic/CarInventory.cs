﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveWellApp.BusinessLogic
{
    public class CarInventory // creating car inventory class for storing car objects
    {
        private List<Car> cars;
        

        public CarInventory() // putting two hardcoded value in cars list
        
        {
            cars = new List<Car>();
            Car car1 = new Car("1314245678919ABCD", "Mercedes", CarType.Sedan, 40000f, 2020);
            cars.Add(car1);
            UsedCar car2 = new UsedCar(1000, "1202920323929FGTD", "BMW", CarType.SUV, 60000, 2021);
            cars.Add(car2);

        }
        public Car GetByVin(string vin) 
        {
            foreach(Car car in cars)
            {
                if (car.Vin == vin)
                    return car;
            }
        return null;
        }
        public void AddCar(Car car)// function to add car
        {
            if (GetByVin(car.Vin) == null)
            {
                cars.Add(car);
            }
        }
        public List<Car> Cars // computed property to return cars list
        {
            get { return cars; }
        }

    }
}
