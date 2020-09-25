using System;
using System.Linq;
using DataAccessLayerEF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;

namespace IntegrationTests
{
    [TestClass]
    public class IntegrationTest
    {
        CarRepository repos = new CarRepository();

        [TestMethod]
        public void TestCreateCar()
        {
            var car = repos.CreateCar("Skoda", FuelType.Diesel, 54321, 4);

            Assert.IsNotNull(car);
            Assert.AreEqual("Skoda", car.Brand);
            Assert.AreEqual(FuelType.Diesel, car.Fuel);
            Assert.AreEqual(54321, car.KilometersDriven);
            Assert.AreEqual(4, car.PassengerCapacity);
            Assert.IsTrue(car.Id > 0);
        }

        [TestMethod]
        public void TestGetAllCars()
        {
            var cars = repos.GetCars();

            Assert.IsNotNull(cars);
        }

        [TestMethod]
        public void TestUpdateCar()
        {
            int id = repos.GetCars().Last().Id;

            var car = repos.UpdateCar(id, 123456, null);

            Assert.AreEqual(123456, car.KilometersDriven);
            Assert.IsNull(car.Location);
        }
       
        [TestMethod]
        public void TestDeleteCar()
        {
            int id = repos.GetCars().First().Id;
            var result = repos.DeleteCar(id);

            Assert.IsTrue(result);
        }
    }
}
