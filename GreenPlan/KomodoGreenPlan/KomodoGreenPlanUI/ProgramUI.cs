using KomodoGreenPlan.POCO;
using KomodoGreenPlan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlanUI
{
    public class ProgramUI
    {
        private readonly VehicleRepo _vehicleRepo = new VehicleRepo();
        public void Run()
        {
            RunApplication();
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to the Komodo Insurance Green Plan Portal! Here, you'll be able to register vehicles to compare\n" +
                " as part of Komodo Insurances' move to help decrease carbon dioxide emissions and make the world more green!\n" +
                "" +
                "***********************************************************************************************************************\n" +
                "\n" +
                "To begin, select one of the following options below:\n" +
                "\n" +
                "1. Register a new vehicle\n" +
                "2. View all registered vehicles\n" +
                "3. View a single vehicle\n" +
                "4. Update an existing vehicle\n" +
                "5. Delete a registered vehicle\n" +
                "6. End Application");
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Menu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        RegisterVehicle();
                        break;
                    case "2":
                        ViewAllVehicles();
                        break;
                    case "3":
                        ViewSingleVehicle();
                        break;
                    case "4":
                        UpdateVehicleByVin();
                        break;
                    case "5":
                        DeleteVehicleByVin();
                        break;
                    case "6":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void DeleteVehicleByVin()
        {
            Console.Clear();
            Console.WriteLine("Please enter the vin number to delete a vehicle: ");
            int vin = Convert.ToInt32(Console.ReadLine());
            _vehicleRepo.DeleteVehicle(vin);
            Console.WriteLine("This vehicle has now been removed from the Green Plan Portal.");
            Console.ReadKey();

        }

        public void UpdateVehicleByVin()
        {
            Console.Clear();
            Console.WriteLine("Please enter the vin of the vehicle you wish to update: ");
            int vin = Convert.ToInt32(Console.ReadLine());

           Vehicle updateVehicle = _vehicleRepo.GetVehicleByVin(vin);
            _vehicleRepo.UpdateVehicle(vin, updateVehicle);

        }

        private void ViewSingleVehicle()
        {
            Console.Clear();
            Console.WriteLine("Please enter the vin of the vehicle you wish to view: ");

            int vin = Convert.ToInt32(Console.ReadLine());
            Vehicle registeredVehicle = _vehicleRepo.GetVehicleByVin(vin);
            DisplayVehicleInfo(registeredVehicle);
            Console.ReadLine();
        }

        private void ViewAllVehicles()
        {
            Console.Clear();

            List<Vehicle> listOfVehicleInfo = _vehicleRepo.GetVehicleInfo();

            foreach (var vehicle in listOfVehicleInfo)
            {
                DisplayVehicleInfo(vehicle);
            }
            Console.ReadLine();
        }

        private void RegisterVehicle()
        {
            Console.Clear();
            Console.WriteLine("To begin registering a vehicle, answer the following prompts to store the vehicle information: ");

            Console.WriteLine("Enter the make of the vehicle: ");
            string userInputVehicleBrand = Console.ReadLine();

            Console.WriteLine("Enter the model of the vehicle: ");
            string userInputCarModel = Console.ReadLine();

            Console.WriteLine("Please enter the miles per gallon (MPG) of this vehicle: ");
            int userInputCarMpg;
            while (!int.TryParse(Console.ReadLine(), out userInputCarMpg))
            {
                Console.WriteLine($"Please enter a valid value for the miles per gallon of the {userInputVehicleBrand} + {userInputCarModel}");
            }

            Console.WriteLine("Please enter the number of seats in the vehicle: ");
            int userInputCarSeatNum;
            while (!int.TryParse(Console.ReadLine(), out userInputCarSeatNum))
            {
                Console.WriteLine("Please enter a valid number for the number of seats in this vehicle: ");
            }

            Console.WriteLine("Select which engine tier best describes the engine type of this vehicle:\n" +
                "1. Tier 1 - Gas\n" +
                "2. Tier 2 - Hybrid\n" +
                "3. Tier 3 - Electric");
            int userInputCarEngine = int.Parse(Console.ReadLine());

            CarEngineType carEngineType = (CarEngineType)userInputCarEngine;

            Vehicle vehicleInfoToBeAdded = new Vehicle(userInputVehicleBrand, userInputCarModel, userInputCarMpg, userInputCarSeatNum, carEngineType);

            bool isSuccessfull = _vehicleRepo.CreateVehicle(vehicleInfoToBeAdded);
            if (isSuccessfull)
            {
                Console.WriteLine($"The information for {userInputVehicleBrand} + {userInputCarModel} was successfully added!");
            }
            else
            {
                Console.WriteLine($"The information for {userInputVehicleBrand} + {userInputCarModel} was not successfully added. Please enter in the information again!");
            }

        }

        public void DisplayVehicleInfo(Vehicle vehicle)
        {
            Console.WriteLine($"{vehicle.CarBrand}\n" +
                $"{vehicle.CarModel}\n" +
                $"{vehicle.CarMilesPerGal}\n" +
                $"{vehicle.CarSeatNum}\n" +
                $"{vehicle.Vin}\n" +
                $"{vehicle.CarEngine}\n" +
                $"****************************************************************************************************");
        }
    }
}
