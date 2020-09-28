using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class ClaimRepo : Claim
    {
        protected readonly List<Claim> _claimDB = new List<Claim>();

        public bool AddClaim(Claim claim)
        {
            int startingCount = _claimDB.Count;
            _claimDB.Add(claim);
            bool wasAdded = (_claimDB.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Claim> GetClaims()
        {
            return _claimDB;
        }

        public bool HandleClaim(Claim claim)
        {
            bool handleClaimResult = _claimDB.Remove(claim);
            return handleClaimResult;
        }

    }
}
