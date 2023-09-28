using AutomobileLibrary.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class CarDBContext
    {
        private static List<Car> carList = new List<Car>()
        {
            new Car{ carID =1, carName = "CRV", manufacturer="Honda", price = 30000, releaseYear = 2021},
            new Car{ carID = 2, carName = "Ford Focus", manufacturer ="Ford", price = 15000, releaseYear = 2020}
        };

        //-----------------------------------
        //Using Singleton Pattern

        private static CarDBContext instance = null;
        private static readonly object instanceLock = new object();
        private CarDBContext() { }

        public static CarDBContext getInstance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    return instance;
                }
            }
        }
        //------------------------------------------

        public List<Car> getCarList => carList;
        //-----------------------------------------
        public Car getCarByID(int carID)
        {
            //using LINQ to Object
            Car car = carList.SingleOrDefault(pro => pro.carID == carID);
            return car;
        }
        //-------------------------------
        //Add new car
        public void addNewCar(Car car)
        {
            Car pro = getCarByID(car.carID);
            if(pro == null)
            {
                carList.Add(car);
            }
            else
            {
                throw new Exception("Car is allredy exits.");
            }
        }
        //Update a car
        public void updateCar(Car car)
        {
            Car c = getCarByID(car.carID);
            if (c != null)
            {
                var index = carList.IndexOf(c);
                carList[index] = car;
            }
            else
            {
                throw new Exception("Car does not already exits.");
            }
        }
        //-------------------------------------------
        //Remove a car
        public void removeCar(int carID)
        {
            Car p = getCarByID(carID);
            if (p != null)
            {
                carList.Remove(p);
            }
            else
            {
                throw new Exception("Car does not already exits.");
            }
        }
        //end remove
    }//end class
}
