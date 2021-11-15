using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Insurance_Console.Repository
{
    public class Badge
    {
        public Dictionary<int, string> _badgeDictionary;
        public Badge() { }
        public Badge(int id, string doors)
        {
            Id = id;
            Doors = doors;
        }
        public int Id { get; set; }
        public string Doors { get; set; }
    }
}
