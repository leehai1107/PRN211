using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public IEnumerable<Car> GetCars() => CarDBContext.getInstance.getCarList;
        public Car getCarByID(int carId) => CarDBContext.getInstance.getCarByID(carId);
        public void insertCar(Car car) => CarDBContext.getInstance.addNewCar(car);
        public void deleteCar(int carID) => CarDBContext.getInstance.removeCar(carID);
        public void updateCar(Car car) => CarDBContext.getInstance.updateCar(car);
    }
}
