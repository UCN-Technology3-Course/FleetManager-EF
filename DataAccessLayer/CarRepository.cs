using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CarRepository
    {
        public Car CreateCar(string brand, FuelType fuelType, int kilometersDriven, int passengerCapacity)
        {
            using (var context = new CarContext())
            {
                var car = new Car
                {
                    Brand = brand,
                    Fuel = fuelType,
                    KilometersDriven = kilometersDriven,
                    PassengerCapacity = passengerCapacity
                };

                context.Cars.Add(car);

                if (context.SaveChanges() == 1)
                {
                    return car;
                }
                return null; 
            }
        }

        public IEnumerable<Car> GetCars()
        {
            using (var context = new CarContext())
            {
                return context.Cars.ToList(); 
            }
        }

        public Car UpdateCar(int id, int kilometersDriven, Location location)
        {
            using (var context = new CarContext())
            {
                var car = context.Cars.Single(c => c.Id == id);
                car.KilometersDriven = kilometersDriven;
                car.Location = location;
                if (context.SaveChanges() == 1)
                {
                    return car;
                }
                return null; 
            }
        }

        public bool DeleteCar(int id)
        {
            using (var context = new CarContext())
            {
                var car = context.Cars.Single(c => c.Id == id);
                context.Cars.Remove(car);
                return context.SaveChanges() == 1;
            }
        }
    }
}
