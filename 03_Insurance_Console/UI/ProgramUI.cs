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
                "1. Add a badge\n"+
                "2. Edit a badge\n"+
                "3. List all badges\n");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        break;
                }
            }
        }
    }
}
