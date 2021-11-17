using _01_Cafe_Console.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console.UI
{
    public class ProgramUI
    {
        private readonly MenuRepo _Repo = new MenuRepo();
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
"░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗  ████████╗░█████╗░\n" +
"░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝  ╚══██╔══╝██╔══██╗\n" +
"░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░  ░░░██║░░░██║░░██║\n" +
"░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░  ░░░██║░░░██║░░██║\n" +
"░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗  ░░░██║░░░╚█████╔╝\n" +
"░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝  ░░░╚═╝░░░░╚════╝░\n\n\n" +
"██╗░░██╗░█████╗░███╗░░░███╗░█████╗░██████╗░░█████╗░  ░█████╗░░█████╗░███████╗███████\n╗" +
"██║░██╔╝██╔══██╗████╗░████║██╔══██╗██╔══██╗██╔══██╗  ██╔══██╗██╔══██╗██╔════╝██╔════╝\n " +
"█████═╝░██║░░██║██╔████╔██║██║░░██║██║░░██║██║░░██║  ██║░░╚═╝███████║█████╗░░█████╗░\n░" +
" █╔═██╗░██║░░██║██║╚██╔╝██║██║░░██║██║░░██║██║░░██║  ██║░░██╗██╔══██║██╔══╝░░██╔══╝░░\n" +
" ██║░╚██╗╚█████╔╝██║░╚═╝░██║╚█████╔╝██████╔╝╚█████╔╝  ╚█████╔╝██║░░██║██║░░░░░███████╗\n" +
"╚═╝░░╚═╝░╚════╝░╚═╝░░░░░╚═╝░╚════╝░╚═════╝░░╚════╝░  ░╚════╝░╚═╝░░╚═╝╚═╝░░░░░╚══════╝\n\n\n\n" +
                    "Enter the number of the option you'd like to select\n" +
                    "\n" +
                    "1. Show all Items\n" +
                    "2. Find Items by Number\n" +
                    "3. Create New Item\n" +
                    "4. Delete Item\n" +
                    "5. Exit\n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllMenus();
                        break;
                    case "2":
                        GetMenusByNumber();
                        break;
                    case "3":
                        CreateNewItem();
                        break;
                    case "4":
                        DeleteExistingProfile();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5.");
                        AnyKey();
                        break;
                }
            }
        }
        private void CreateNewItem()
        {
            Console.Clear();
            Menu menu = new Menu();
            Console.WriteLine("Please enter a number:");
            menu.Number = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Please enter a name:");
            menu.Name = Console.ReadLine().ToLower();
            Console.Clear();
            Console.WriteLine("Please enter a description:");
            menu.Description = Console.ReadLine().ToLower();
            Console.Clear();
            Console.WriteLine("Please enter a list of ingredients:");
            menu.Ingredients = Console.ReadLine().ToLower();
            Console.Clear();
            Console.WriteLine("Please enter a price:");
            menu.Price = Convert.ToDecimal(Console.ReadLine());
            Console.Clear();
            if (_Repo.AddMenuToDirectory(menu))
            {
                Console.WriteLine("Item Added!\n\n");
                AnyKey();
            }
        }
        private void ShowAllMenus()
        {
            Console.Clear();
            List<Menu> listOfItems = _Repo.GetMenu();
            foreach (Menu menu in listOfItems)
            {
                DisplayMenu(menu);
            }
            AnyKey();
        }
        private void GetMenusByNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter Item Number: ");
            int itemInput = Convert.ToInt32(Console.ReadLine());
            List<Menu> listOfItems = _Repo.GetMenu();
            foreach (Menu menu in listOfItems)
            {
                if (itemInput == menu.Number)
                {
                    Console.Clear();
                    DisplayMenu(menu);
                }
            }
            AnyKey();
        }
        public void DeleteExistingProfile()
        {
            Console.WriteLine("Here is a list of items you can delete:");
            List<Menu> listOfItems = _Repo.GetMenu();
            ShowAllMenus();
            Console.Clear();
            Console.WriteLine("Enter the number of the item you would like to delete:");
            int numberInput = Convert.ToInt32(Console.ReadLine());
            foreach (Menu menu in listOfItems.ToList())
            {
                if (numberInput == menu.Number)
                {
                    Console.Clear();
                    bool deleteMusician = _Repo.Remove(menu);
                    if (deleteMusician == true)
                    {
                        Console.WriteLine("Item Deleted!\n");
                        AnyKey();
                    }
                }
            }
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continute...");
            Console.ReadKey();
        }
        private void DisplayMenu(Menu menu)
        {
            Console.WriteLine(
                $"Number: {menu.Number}\n" +
                $"Name: {menu.Name}\n" +
                $"Decription: {menu.Description}\n" +
                $"Ingredients: {menu.Ingredients}\n" +
                $"Price: ${menu.Price}\n");
        }
        public void SeedContent()
        {
            Menu item1 = new Menu(1, "Hamburger", "Tasty!", "Tomatoes, Beef, Wheat", 4.35m);
            Menu item2 = new Menu(2, "Fries", "Crispy!", "Potatoes, Salt", 2.85m);
            Menu item3 = new Menu(3, "Hot Fudge Sundae", "Sweet!", "Dairy, Chocolate, Nuts", 3.65m);
            _Repo.AddMenuToDirectory(item1);
            _Repo.AddMenuToDirectory(item2);
            _Repo.AddMenuToDirectory(item3);
        }
    }
}
