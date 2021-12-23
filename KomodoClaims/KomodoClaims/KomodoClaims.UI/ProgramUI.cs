using KomodoClaims.POCO;
using KomodoClaims.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims.UI
{

    public class ProgramUI
    {
        private readonly ClaimsRepo _claimsRepo = new ClaimsRepo();
        private static int _tableWidth = Console.WindowWidth;


        public void Run()
        {
            RunApplication();
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to the Komodo Insurance Claims Portal! Here, you will be able to enter a new claim, view all claims or a single claim, and handle claims. To begin, please select an option from the following menu: \n" +
                "************************************************************************************************************************\n" +
                "1. Create a new claim\n" +
                "2. See all claims\n" +
                "3. Handle a claim\n" +
                "4. Close the Komodo Insurance Claims Portal");
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
                        CreateClaim();
                        break;
                    case "2":
                        SeeAllClaims();
                        break;
                    case "3":
                        HandleClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void HandleClaim()
        {
            Console.Clear();
            Console.WriteLine("Would you like to handle the next claim?");
           // Claims listOfClaims = _claimsRepo.GetClaimInfo();
            DisplayClaimsInfo(_claimsRepo.GetClaimInfo());
            Console.WriteLine("Would you like to handle the claim? y/n:");
            string userInputClaim = Console.ReadLine().ToLower();
            if (userInputClaim == "y")
            {
                _claimsRepo.RemoveClaim();
            }
            else
            {
                Menu();
            }
            Console.WriteLine();

        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Console.WriteLine(String.Format("|{0, -25}|{1,-25}|{2,-25}|{3,-15}|{4,-15}|{5,-15}|{6,-10}|", "ClaimID", "Claim Type", "Description", "Amount", "Date of Accident", "Date of Claim", "Claim Handled"));
            PrintLine();
            foreach (var claims in _claimsRepo.ViewAllClaims())
            {
                Console.WriteLine(String.Format("|{0, -25}|{1,-25}|{2,-25}|{3,-15}|{4,-15}|{5,-15}|{6,-10}|", claims.ClaimId, claims.ClaimType, claims.Description, claims.ClaimAmount, claims.DateOfIncident, claims.DateOfClaim, claims.IsValid));
            }
            Console.ReadLine();
        }

        public void DisplayClaimsInfo(Claims claims)
        {
            Console.WriteLine($"{claims.ClaimId}\n" +
                $"{claims.ClaimType}\n" +
                $"{claims.Description}\n" +
                $"{claims.ClaimAmount}\n" +
                $"{claims.DateOfIncident}\n" +
                $"{claims.DateOfClaim}\n" +
                $"{claims.IsValid}");
        }

        private void CreateClaim()
        {
            Console.Clear();
            Console.WriteLine("Complete the following information to file a claim:");

            Console.WriteLine("Enter the claim ID: ");
            int userInputClaimId;
            while (!int.TryParse(Console.ReadLine(), out userInputClaimId))
            {
                Console.WriteLine("Please enter a valid number for the Claim ID: ");
            }

            Console.WriteLine("Enter the type of claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Tehft ");
            string userInputClaimType = Console.ReadLine();
            ClaimsType answer = ClaimsType.Car;
            switch (userInputClaimType)
            {
                case "1":
                    answer = ClaimsType.Car;
                    break;
                case "2":
                    answer = ClaimsType.Home;
                    break;
                case "3":
                    answer = ClaimsType.Theft;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number: 1, 2, or 3.");
                    break;

            }
                       

            Console.WriteLine("Enter the description of the claim: ");
            string userInputDescription = Console.ReadLine();

            Console.WriteLine("Enter in the amount of damages: ");
            int userInputClaimAmount;
            while (!int.TryParse(Console.ReadLine(), out userInputClaimAmount))
            {
                Console.WriteLine("Please enter a valid number for the amount of damages: ");
            }

            Console.WriteLine("Enter the date of the incident: ");
            DateTime userInputDateIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter in the date the claim was filed: ");
            DateTime userInputDateOfClaim = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Is this claim valid? y/n: ");
            string isValidInput = Console.ReadLine().ToLower();
            bool userInputIsValid;
            if (isValidInput == "y")
            {
                userInputIsValid = true;
            }
            else
            {
                userInputIsValid = false;
            }
            Console.Clear();


            Claims claimInfoToAdd = new Claims(answer, userInputDescription, userInputClaimAmount, userInputDateIncident, userInputDateOfClaim, userInputIsValid);

            bool isSuccessfull = _claimsRepo.CreateClaim(claimInfoToAdd);
            if (isSuccessfull)
            {
                Console.WriteLine("You have created a new claim!");
            }
            else
            {
                Console.WriteLine("Your claim was not entered in the portal. Please try again.");
            }
        }


        //Helper Methods
        private static void PrintLine()
        {
            Console.WriteLine(new string('_', _tableWidth));
        }
    }
}
