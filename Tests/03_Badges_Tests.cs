using _03_Badges_Console.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class Badges_Tests
    {
        private BadgeRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
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
            List<string> doors = new List<string> { "A5", "A6" };
            int id = 34567;
            _repo.CreateNewBadge(id, doors);
            Dictionary<int, List<string>> badges = _repo.GetBadges();
            bool hasBadges = doors.Contains("A5");
            Assert.IsTrue(hasBadges);
        }
        [TestMethod]
        public void AddDoor_ShouldComeBackTrue()
        {
            string door = "A4";
            int id = 12345;
            bool addDoor = _repo.AddDoor(id, door);
            Assert.IsTrue(addDoor);
        }
        [TestMethod]
        public void DeleteBadge_ShouldReturnTrue()
        {
            string door = "A5";
            int id = 12345;
            bool deleteDoor = _repo.RemoveDoor(id, door);
            Assert.IsTrue(deleteDoor);
        }
    }
}
