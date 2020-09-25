using System;
using System.Linq;
using System.Security.Cryptography;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;

namespace IntegrationTests
{
    [TestClass]
    public class IntegrationTest
    {
        private CarRepository _repos = new CarRepository();

        [TestMethod]
        public void TestCreateCar()
        {
            var car = _repos.CreateCar("Suzuki", FuelType.Diesel, 54321, 4);

            Assert.IsNotNull(car);
            Assert.IsTrue(car.Id > 0);
            Assert.AreEqual("Suzuki", car.Brand);
            Assert.AreEqual(54321, car.KilometersDriven);
            Assert.AreEqual(FuelType.Diesel, car.Fuel);
            Assert.AreEqual(4, car.PassengerCapacity);
        }

        [TestMethod]
        public void TestUpdateCar()
        {
            var car = _repos.GetCars().First();

            int kilometersDriven = car.KilometersDriven + 1234;

            car = _repos.UpdateCar(car.Id, kilometersDriven, null);

            Assert.IsNotNull(car);
            Assert.AreEqual(kilometersDriven, car.KilometersDriven);
        }

        [TestMethod]
        public void TestDeleteCar()
        {
            var id = _repos.GetCars().Last().Id;

            var result = _repos.DeleteCar(id);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetCars()
        {
            var cars = _repos.GetCars();

            Assert.IsNotNull(_repos);            
        }
    }
}
