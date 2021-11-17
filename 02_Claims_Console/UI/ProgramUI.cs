using _02_Claims_Console.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console.UI
{
    public class ProgramUI
    {
        private readonly ClaimRepo _repo = new ClaimRepo();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                    "Choose a menu item:\n" +
                    "\n" +
                    "1. See All Claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit\n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        DisplayNextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4.");
                        AnyKey();
                        break;
                }
            }
        }
        private void ShowAllClaims()
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _repo.GetClaims();
            Console.WriteLine("ClaimID  Type     Description         Amount          DateOfIncident          DateOfClaim         IsValid");
            foreach (Claim claim in queueOfClaims)
            {
                DisplayClaims(claim);
            }
            AnyKey();
        }
        private void CreateNewClaim()
        {
            Console.Clear();
            Claim claim = new Claim();
            Console.WriteLine("Enter the claim id:");
            claim.Id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Please select a Type:\n\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string instrumentInput = Console.ReadLine();
            int instrumentId = int.Parse(instrumentInput);
            claim.ClaimType = (ClaimType)instrumentId;
            Console.Clear();
            Console.WriteLine("Enter a claim description:");
            claim.Description = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Amount of Damage:");
            claim.Amount = Convert.ToDecimal(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Date of Incident:");
            claim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Date of Claim:");
            claim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("This claim is valid (true/false):");
            claim.IsValid = Convert.ToBoolean(Console.ReadLine());
            Console.Clear();
            if (_repo.AddClaimToDirectory(claim))
            {
                Console.WriteLine("Claim Added!");
                AnyKey();
            }
        }
        private void DisplayNextClaim()
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _repo.GetClaims();
            foreach (Claim claim in queueOfClaims.ToList())
            {
                Console.WriteLine("Here are the details for the next claim to be handled:\n\n");
                Console.WriteLine(
                    $"ClaimID: {claim.Id}\n" +
                    $"Type: {claim.ClaimType}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Amount: {claim.Amount}\n" +
                    $"DateOfIncident: {claim.DateOfIncident}\n" +
                    $"DateOfClaim: {claim.DateOfClaim}\n" +
                    $"IsValid: {claim.IsValid}\n\n");
                Console.WriteLine("Would you like to take care of this claim?(y/n)");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "y":
                        Console.Clear();
                        queueOfClaims.Dequeue();
                        Console.Clear();
                        _repo.GetNextClaim();
                        break;
                    case "n":
                        RunMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter 'Y' or 'N'...");
                        break;
                }
            }
            AnyKey();
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void DisplayClaims(Claim claim)
        {
            Console.WriteLine($"{claim.Id}      {claim.ClaimType}     {claim.Description}   ${claim.Amount}        {claim.DateOfIncident.ToString("MM/dd/yy")}                   {claim.DateOfClaim.ToString("MM/dd/yy")}            {claim.IsValid}");
        }
        private void SeedContent()
        {
            Claim claim1 = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 25), true);
            Claim claim2 = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            Claim claim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01), false);
            _repo.AddClaimToDirectory(claim1);
            _repo.AddClaimToDirectory(claim2);
            _repo.AddClaimToDirectory(claim3);
        }
    }
}
