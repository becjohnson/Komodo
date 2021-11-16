using _03_Badges_Console.Repository;
using _03_Insurance_Console.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class Insurance_Tests
    {
        private Badge _badges;
        private BadgeRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new InsuranceRepo();
            Badge badge1 = new Badge(827292, new List<string> { "A5", "A7" } );
        }
        [TestMethod]
        public void AddBadgeToDictionary_ShouldComeBackTrue()
        {
            Badge badge = new Badge() { Doors = new List<string> { "B6", "C6", }, Id = 20983 };
            _repo.AddBadgeToDirectory(badge);
            bool addBadge = _repo.AddBadgeToDirectory(badge);
            Assert.IsTrue(addBadge);
        }
        [TestMethod]
        public void GetDictionary_ShouldReturnCorrectCollection()
        {
            Badge badge = new Badge();
            _repo.AddBadgeToDirectory(badge);
            Dictionary<int, List<string>> contents = _repo.GetBadges();
            bool directoryHasContent = contents.ContainsValue(badge.Doors);
            Assert.IsTrue(directoryHasContent);
        }
    }
}
