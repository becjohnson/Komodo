using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Insurance_Console.Repository
{
    public class InsuranceRepo
    {
        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        public bool AddBadgeToDirectory(Badge badge)
        {
            int startingCount = _badgeDictionary.Count;
            _badgeDictionary.Add(badge.Id, badge.Doors);
            bool wasAdded = (_badgeDictionary.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public Dictionary<int, List<string>> GetBadges()
        {
            return _badgeDictionary;
        }
        public void AddToAccessList(Badge badge)
        {
            _badgeDictionary.Add(badge.Id, badge.Doors);
        }
        public bool AddDoorToBadge(Badge badge)
        {
            if (_badgeDictionary.ContainsKey(badge.Id))
            {
                foreach (string s in badge.Doors)
                {
                    _badgeDictionary[badge.Id].Add(s);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDoor(Badge badge)
        {
            if (_badgeDictionary.ContainsKey(badge.Id))
            {
                foreach (string s in badge.Doors)
                {
                    _badgeDictionary[badge.Id].Remove(s);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetDoorAccessByID(int id)
        {
            foreach (KeyValuePair<int, List<string>> keyValuePair in _badgeDictionary)
            {
                if (keyValuePair.Key == id)
                {
                    string badgeAccessList = string.Join(", ", keyValuePair.Value);
                    return badgeAccessList;
                }
            }
            return null;
        }
        public bool DeleteBadge(int id)
        {
            int startingCount = _badgeDictionary.Count;
            if (_badgeDictionary.ContainsKey(id))
            {
                _badgeDictionary.Remove(id);
            }
            if (startingCount > _badgeDictionary.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EditBadge(int id, string doors, bool isAdded)
        {
            List<string> listOfBadges = _badgeDictionary[id];
            if (isAdded)
            {
                listOfBadges.Add(doors);
                return true;
            }
            else
            {
                listOfBadges.Remove(doors);
                return false;
            }
        }
    }
}
