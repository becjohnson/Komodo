using _03_Insurance_Console.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Insurance_Console.UI
{
    class ProgramUI
    {
        protected readonly InsuranceRepo _repo = new InsuranceRepo();
        public void Run()
        {
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Hello Security Admin. What would you like to do?\n" +
                "1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all badges\n");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        break;
                    case "3":
                        GetBadges();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        break;
                }
            }
        }
        public void AddBadge()
        {
            Badge badge = new Badge();
            Console.WriteLine("What is the number on the badge?");
            badge.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("List a door that it needs access to:");
            string doorName1 = Console.ReadLine().ToUpper();
            badge.Doors = doorName1.Split(' ').ToList();
            Console.WriteLine("Any other doors(y/n)?");
            string input1 = Console.ReadLine();
            switch (input1)
            {
                case "y":
                    Console.WriteLine("List a door it needs access to:");
                    string doorName2 = Console.ReadLine();
                    badge.Doors = doorName2.Split(' ').ToList();
                    Console.WriteLine("Any other doors(y/n)?");
                    string input2 = Console.ReadLine().ToLower();
                    switch (input2)
                    {
                        case "y":
                            Console.WriteLine("List a door it needs access to:");
                            string doorName3 = Console.ReadLine();
                            badge.Doors = doorName3.Split(' ').ToList();
                            _repo.AddBadgeToDirectory(badge);
                            break;
                        case "n":
                            RunMenu();
                            break;
                        default:
                            Console.WriteLine("Please enter a valid selection.");
                            break;
                    }
                    break;
                case "n":
                    _repo.AddBadgeToDirectory(badge);
                    RunMenu();
                    break;
                    Console.WriteLine("Please enter a valid selection.");
                default:
                    break;
            }
        }
        public void GetBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> keyValuePairs = _repo.GetBadges();
            foreach (var keyvalue in keyValuePairs)
            {
                DisplayBadge(keyvalue.Key);
                AnyKey();
            }
            AnyKey();
        }
        public void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void DisplayBadge(int BadgeId)
        {
            _repo.GetDoorAccessByID(BadgeId);
        }
    }
}