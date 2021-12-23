using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan.POCO
{
        public enum CarEngineType
        {
            Tier_1_Gas = 1,
            Tier_2_Hybrid,
            Tier_3_Electric
        }

    public class Vehicle
    {
        public Vehicle()
        {

        }


        public Vehicle(string carBrand, string carModel, double carMilesPerGal, int carSeatNum, CarEngineType carEngine)
        {
            CarBrand = carBrand;
            CarModel = carModel;
            CarMilesPerGal = carMilesPerGal;
            CarSeatNum = carSeatNum;
            CarEngine = carEngine;

        }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public double CarMilesPerGal { get; set; }
        public int CarSeatNum { get; set; }
        public int Vin { get; set; }
        public CarEngineType CarEngine { get; set; }


    }

    

}
