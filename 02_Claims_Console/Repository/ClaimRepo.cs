using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console.Repository
{
    public class ClaimRepo
    {
        protected readonly Queue<Claim> _claimDirectory = new Queue<Claim>();
        protected readonly Queue<Claim> _claimQueue = new Queue<Claim>();
        public bool AddClaimToDirectory(Claim claim)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Enqueue(claim);
            bool wasAdded = (_claimDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public Queue<Claim> GetClaims()
        {
            return _claimDirectory;
        }
        public Queue<Claim> GetNextClaim()
        {
            return _claimQueue;
        }
    }
}
