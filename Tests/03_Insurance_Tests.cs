using _03_Insurance_Console.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Insurance_Tests
    {
        private InsuranceRepo _repo;
        [TestInitialize]
        public void Arrange()
        {

        }
        [TestMethod]
        public void AddBadgeToDictionary_ShouldComeBackTrue()
        {
            Badge badge = new Badge();
            InsuranceRepo repository = new InsuranceRepo();
            bool addResult = repository.AddBadgeToDirectory(badge);
            Assert.IsTrue(addResult);
        }


    }
}
