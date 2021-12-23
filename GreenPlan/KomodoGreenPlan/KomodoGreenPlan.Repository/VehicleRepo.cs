using KomodoGreenPlan.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan.Repository
{
    public class VehicleRepo
    {
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();

        private int _count = 0;

        public bool CreateVehicle(Vehicle vehicle)
        {
            if (vehicle is null)
            {
                return false;
            }
            else
            {
                Console.WriteLine("You have completed entering in this vehicle's information!");
            }
            _count++;
            vehicle.Vin = _count++;
            _vehicles.Add(vehicle);
            return true;
        }

        public List<Vehicle> GetVehicleInfo()
        {
            return _vehicles;
        }

        public Vehicle GetVehicleByVin(int vin)
        {
            foreach(Vehicle vehicle in _vehicles)
            {
                if (vin == vehicle.Vin)
                {
                    return vehicle;
                }
            }
            return null;
        }

        public bool UpdateVehicle(int vin, Vehicle newVehicleInfo)
        {
            Vehicle oldVehicleInfo = GetVehicleByVin(vin);

            if(oldVehicleInfo != null)
            {
                oldVehicleInfo.CarBrand = newVehicleInfo.CarBrand;
                oldVehicleInfo.CarModel = newVehicleInfo.CarModel;
                oldVehicleInfo.CarMilesPerGal = newVehicleInfo.CarMilesPerGal;
                oldVehicleInfo.CarSeatNum = newVehicleInfo.CarSeatNum;
                oldVehicleInfo.Vin = newVehicleInfo.Vin;
                oldVehicleInfo.CarEngine = newVehicleInfo.CarEngine;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteVehicle(int vin)
        {
            Vehicle vehicleDelete = GetVehicleByVin(vin);

            if(vehicleDelete == null)
            {
                return false;
            }
            else
            {
                _vehicles.Remove(vehicleDelete);
                return true;
            }
        }

    }
}
