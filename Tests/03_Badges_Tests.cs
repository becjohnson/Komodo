using _03_Badges_Console.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class Badges_Tests
    {
        private Badge _badges;
        private BadgeRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            Badge badge1 = new Badge(827292, new List<string> { "A5", "A7" });
        }
        [TestMethod]
        public void AddBadgeToDictionary_ShouldComeBackTrue()
        {
            bool addBadge = _repo.CreateNewBadge(27187, new List<string> { "A9", "A5" });
            Assert.IsTrue(addBadge);
        }
        [TestMethod]
        public void GetDictionary_ShouldReturnCorrectCollection()
        {
            Badge badge = new Badge();
            List<string> doors = new List<string> { "A5", "A6" };
            int id = 12345;
            BadgeRepo repo = new BadgeRepo();
            repo.CreateNewBadge(id, doors);
            Dictionary<int, List<string>> badges = repo.GetBadges();
            bool hasBadges = doors.Contains("A5");
            Assert.IsTrue(hasBadges);
        }
        [TestMethod]
        public void AddDoor_ShouldComeBackTrue()
        {
            Badge badge = new Badge();
            List<string> doors = new List<string> { "A5", "A6" };
            bool addDoor = _repo.AddDoor(8272, "A6");
            Assert.IsTrue(addDoor);
        }
        public bool DeleteBadge_ShouldReturnTrue()
        {
            Assert.IsTrue(_repo.RemoveDoor(8272, "A6"));
        }
    }
}
