using _02_Claims_Console.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class UnitTest2
    {
        private ClaimRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepo();
            Claim claim1 = new Claim(1, ClaimType.Car, "Car Accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            Claim claim2 = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            Claim claim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 6, 18), false);
            _repo.AddClaimToDirectory(claim1);
            _repo.AddClaimToDirectory(claim2);
            _repo.AddClaimToDirectory(claim3);
        }
        [TestMethod]
        public void EnterNewClaim_ShouldAddClaimToDirectory()
        {
            Claim claim = new Claim();
            bool addResult = _repo.AddClaimToDirectory(claim);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void SeeAllClaims_ShouldReturnCorrectCollection()
        {
            Claim claim = new Claim();
            _repo.AddClaimToDirectory(claim);
            Queue<Claim> claims = _repo.GetClaims();
            bool directoryHasClaims = claims.Contains(claim);
            Assert.IsTrue(directoryHasClaims);
        }
        [TestMethod]
        public void GetNextClaim_ShouldReturnCorrectCollection()
        {
            Claim claim = new Claim();
            _repo.AddClaimToDirectory(claim);
            Queue<Claim> claims = _repo.GetNextClaim();
            bool directoryHasClaims = claims.Contains(claim);
            Assert.IsTrue(directoryHasClaims);
        }
        [TestMethod]
        public void DeleteClaim()
        {
            _repo.DeleteClaim();
            bool wasDeleted = _repo.DeleteClaim();
            Assert.IsTrue(wasDeleted);
        }
    }
}
