using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console.Repository
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>
        {
            {12345, new List<string> {"A9", "A5" } },
            {23456, new List<string> {"A7", "A8" } }
        };
        public Dictionary<int, List<string>> GetBadges()
        {
            return _badgeDictionary;
        }
        public bool CreateNewBadge(int id, List<string> doors)
        {
            int startingCount = _badgeDictionary.Count;
            _badgeDictionary.Add(id, doors);
            if (startingCount < _badgeDictionary.Count ? true : false) ;
            return true;
        }
        public bool RemoveDoor(int id, string door)
        {
            List<string> listOfBadges = _badgeDictionary[id];
            if (_badgeDictionary.ContainsKey(id))
            {
                listOfBadges.Remove(door);
                return true;
            }
            return false;
        }
        public bool AddDoor(int id, string door)
        {
            List<string> listOfBadges = _badgeDictionary[id];
            if (_badgeDictionary.ContainsKey(id))
            {
                listOfBadges.Add(door);
                return true;
            }
            return false;
        }
    }
}
