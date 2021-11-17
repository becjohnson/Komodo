using _03_Badges_Console.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console
{
    public class ProgramUI
    {
        protected readonly BadgeRepo _repo = new BadgeRepo();
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
                Console.WriteLine("Hello Security Admin. What would you like to do?\n\n" +
                "1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all badges\n" +
                "4. Exit\n");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        GetBadges();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        break;
                }
            }
        }
        public void CreateNewBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the number on the badge: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("List a door that it needs access to: ");
            string doors1 = Console.ReadLine().ToUpper();
            Console.Clear();
            Console.WriteLine("Any other doors(y/n)?");
            string input1 = Console.ReadLine();
            Console.Clear();
            switch (input1)
            {
                case "y":
                    Console.WriteLine("List a door that it needs access to: ");
                    string doors2 = Console.ReadLine().ToUpper();
                    _repo.CreateNewBadge(id, new List<string> { doors1, doors2 });
                    Console.Clear();
                    Console.WriteLine("Any other doors(y/n)?");
                    string input2 = Console.ReadLine();
                    Console.Clear();
                    switch (input2)
                    {
                        case "y":
                            Console.WriteLine("List a door that it needs access to: ");
                            string doors3 = Console.ReadLine().ToUpper();
                            _repo.CreateNewBadge(id, new List<string> { doors1, doors2, doors3 });
                            break;
                        case "n":
                            Console.Clear();
                            RunMenu();
                            break;
                        default:
                            break;
                    }
                    break;
                case "n":
                    _repo.CreateNewBadge(id, new List<string> { doors1 });
                    Console.Clear();
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please enter y or n..");
                    break;
            }
        }
        public void UpdateBadge()
        {
            Console.Clear();
            Dictionary<int, List<string>> keyValuePairs = _repo.GetBadges();
            Console.WriteLine("What is the number on the badge: ");
            int badgeId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (keyValuePairs.ContainsKey(badgeId))
            {
                foreach (var badge in keyValuePairs)
                {
                    int key = badge.Key;
                    List<string> values = badge.Value;
                    Console.WriteLine(key + " has access to doors " + string.Join(" & ", values));
                    Console.WriteLine("\n");
                    AnyKey();
                    Console.Clear();
                    Console.WriteLine("What would you like to do?\n");
                    Console.WriteLine("1. Remove a door");
                    Console.WriteLine("2. Add a door");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Which door would you like to remove?");
                            string oldDoor = Console.ReadLine().ToUpper();
                            if (keyValuePairs.ContainsKey(badgeId))
                            {
                                Console.Clear();
                                _repo.RemoveDoor(badgeId, oldDoor);
                                Console.WriteLine("Door removed.\n");
                                AnyKey();
                                Console.Clear();
                                Console.WriteLine(key + " has access to doors " + string.Join(" & ", values));
                                Console.WriteLine("\n");
                                AnyKey();
                                RunMenu();
                            }
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("Which door would you like to add?");
                            string newDoor = Console.ReadLine().ToUpper();
                            if (keyValuePairs.ContainsKey(badgeId))
                            {
                                Console.Clear();
                                _repo.AddDoor(badgeId, newDoor);
                                Console.WriteLine("Door added.\n");
                                AnyKey();
                                Console.Clear();
                                Console.WriteLine(key + " has access to doors " + string.Join(" & ", values));
                                Console.WriteLine("\n");
                                AnyKey();
                                RunMenu();
                            }
                            break;
                        default:
                            Console.WriteLine("Please select a valid option...");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No such badge...\n");
                AnyKey();
            }
        }
        public void GetBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> keyValuePairs = _repo.GetBadges();
            Console.WriteLine("Badge#             Door Access\n");
            foreach (var badge in keyValuePairs)
            {
                int key = badge.Key;
                List<string> values = badge.Value;
                Console.WriteLine(key + "              [" + string.Join(",", values) + "]");
            }
            Console.WriteLine("\n");
            AnyKey();
        }
        public void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        public void SeedContent()
        {
            _repo.CreateNewBadge(12345, new List<string> { "A7" });
            _repo.CreateNewBadge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            _repo.CreateNewBadge(32345, new List<string> { "A1", "A5" });
        }
    }
}
