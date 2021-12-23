using KomodoClaims.POCO;
using KomodoClaims.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoClaims.Tests
{
    [TestClass]
    public class UnitTest1
    {
        ClaimsRepo _claimsRepo = new ClaimsRepo();
        Claims _claims = new Claims();
        //Queue<Claims> _claimItems = new Queue<Claims>();

        [TestMethod]
        public void CreateClaim_ReturnsTrue()
        {
            _claims.ClaimId = 1;
            _claims.ClaimType = ClaimsType.Home;
            _claims.Description = "basement flood";
            _claims.ClaimAmount = 2000;
            _claims.DateOfIncident = new DateTime(2021, 10, 14);
            _claims.DateOfClaim = new DateTime(2021, 10, 16);
            _claims.IsValid = true;

            bool newClaimCreated = _claimsRepo.CreateClaim(_claims);

            Assert.IsTrue(newClaimCreated);
        }

        [TestMethod]
        public void GetClaimInfo_ReturnsEqual()
        {
            Claims _claimsOne = new Claims(ClaimsType.Theft, "stolen TV", 500, new DateTime(2021, 9, 7), new DateTime(2021, 9, 7), true);

            _claimsRepo.CreateClaim(_claimsOne);

            _claimsRepo.GetClaimInfo();

            Assert.AreEqual(1, _claimsRepo.GetClaimInfo());
        }

        [TestMethod]
        public void ViewAllClaims_ReturnsEqual()
        {


        }

        [TestMethod]
        public void RemoveClaim_IsTrue()
        {
            Claims _claimOne = new Claims(ClaimsType.Car, "car rear ended", 4000, new DateTime(2021, 07, 04), new DateTime(2021, 07, 10), true);
            _claimsRepo.CreateClaim(_claimOne);

            bool claimOneDelete = _claimsRepo.RemoveClaim();

            Assert.IsTrue(claimOneDelete);

        }
    }
}
