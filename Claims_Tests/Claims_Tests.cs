using System;
using System.Collections.Generic;
using _02_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claims_Tests
{
    [TestClass]
    public class Claims_Tests
    {
        [TestMethod]
        public void AddClaimAddsClaim()
        {
            Claim claim = new Claim();
            ClaimRepo claimRepo = new ClaimRepo();
            bool result = claimRepo.AddClaim(claim);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetClaimsGetsAllClaims()
        {
            Claim claim = new Claim();
            ClaimRepo claimRepo = new ClaimRepo();
            claimRepo.AddClaim(claim);
            List<Claim> claimList = claimRepo.GetClaims();
            bool listNotEmpty = claimList.Contains(claim);
            Assert.IsTrue(listNotEmpty);
        }

        [TestMethod]
        public void HandleClaimRemovesClaimFromDB()
        {
            Claim claim = new Claim();
            ClaimRepo claimRepo = new ClaimRepo();
            claimRepo.AddClaim(claim);
            bool isHandled = claimRepo.HandleClaim(claim);
            Assert.IsTrue(isHandled);
        }
    }
}
