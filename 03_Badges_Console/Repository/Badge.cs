using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console.Repository
{
    public class Badge
    {
        public Dictionary<int, List<string>> _badgeDictionary;
        public Badge() { }
        public Badge(int id, List<string> doors)
        {
            Id = id;
            Doors = doors;
        }
        public int Id { get; set; }
        public List<string> Doors { get; set; }
    }
}
