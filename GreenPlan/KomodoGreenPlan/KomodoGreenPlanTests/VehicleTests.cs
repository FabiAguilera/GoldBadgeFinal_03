using KomodoGreenPlan.POCO;
using KomodoGreenPlan.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoGreenPlanTests
{
    [TestClass]
    public class VehicleTests
    {
        VehicleRepo _vehicleRepo = new VehicleRepo();
        List<Vehicle> _vehicleItems = new List<Vehicle>();
        Vehicle _vehicle = new Vehicle();
        //Vehicle _vehicleItems = new Vehicle();

        private void SeedTest()
        {
            Vehicle _modelOne = new Vehicle("Lexus", "QR-T", 35, 5, CarEngineType.Tier_3_Electric);

            Vehicle _modelTwo = new Vehicle("Volvo", "XC-90", 30, 8, CarEngineType.Tier_2_Hybrid);

            Vehicle _modelThree = new Vehicle("Kia", "Sorento", 25, 7, CarEngineType.Tier_1_Gas);

            Vehicle _modelFour = new Vehicle("Chevy", "TrailBlazer", 18, 5, CarEngineType.Tier_1_Gas);
            _vehicleItems.Add(_modelOne);
            _vehicleItems.Add(_modelTwo);
            _vehicleItems.Add(_modelThree);
            _vehicleItems.Add(_modelFour);

        }


        [TestMethod]
        public void CreateVehicle_ReturnTrue()
        {
            _vehicle.CarBrand = "Hyundai";
            _vehicle.CarModel = "Tuscan";
            _vehicle.CarMilesPerGal = 28;
            _vehicle.Vin = 1;
            _vehicle.CarSeatNum = 5;
            _vehicle.CarEngine = CarEngineType.Tier_2_Hybrid;

            bool vehicleItemCreated = _vehicleRepo.CreateVehicle(_vehicle);

            Assert.IsTrue(vehicleItemCreated);
    }

        [TestMethod]
        public void GetVehicleInfo_ReturnsEqual()
        {
            Vehicle _vehicleOne = new Vehicle("Ford", "Bronco", 18, 5, CarEngineType.Tier_1_Gas);
            _vehicleRepo.CreateVehicle(_vehicleOne);

            _vehicleRepo.GetVehicleInfo();

            Assert.AreEqual(1, _vehicleRepo.GetVehicleInfo().Count);
        }


        [TestMethod]
        public void GetVehicleByVin_ReturnsEqual()
        {
            SeedTest();

            _vehicleRepo.GetVehicleByVin(2);

            Assert.AreEqual(4, _vehicleItems.Count);
        }

        [TestMethod]
        public void UpdateVehicle_ReturnTrue()
        {
            Vehicle originlVehicle = new Vehicle("Kia", "Sorento", 25, 7, CarEngineType.Tier_1_Gas);
            _vehicleRepo.CreateVehicle(originlVehicle);
            Vehicle updatedVehicle = new Vehicle("Kia", "Sorento", 20, 5, CarEngineType.Tier_1_Gas);


            bool vehicleUpdate = _vehicleRepo.UpdateVehicle(1, updatedVehicle);

            Assert.IsTrue(vehicleUpdate);
        }

        [TestMethod]
        public void DeleteVehicle()
        {
            Vehicle _vehicleOne = new Vehicle("Mercedes", "G-Wagon", 18, 8, CarEngineType.Tier_1_Gas);

            _vehicleRepo.CreateVehicle(_vehicleOne);

            bool deleteVehicleOne = _vehicleRepo.DeleteVehicle(1);

            Assert.IsTrue(deleteVehicleOne);
        }
    }
}
