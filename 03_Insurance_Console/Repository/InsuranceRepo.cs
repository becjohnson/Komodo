using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Insurance_Console.Repository
{
    public class InsuranceRepo
    {
        protected readonly Dictionary<string, int> _badgeDictionary = new Dictionary<string, int>();
        public bool AddBadgeToDirectory(Badge badge)
        {
            int startingCount = _badgeDictionary.Count();
            _badgeDictionary.Add(badge.Doors, badge.Id);
            bool wasAdded = (_badgeDictionary.Count > startingCount) ? true : false;
            return wasAdded;
        }
    }
}
