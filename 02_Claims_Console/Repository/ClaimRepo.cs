using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console.Repository
{
    public class ClaimRepo
    {
        protected readonly Queue<Claim> _claimQueue = new Queue<Claim>();
        public bool AddClaimToDirectory(Claim claim)
        {
            int startingCount = _claimQueue.Count;
            _claimQueue.Enqueue(claim);
            bool wasAdded = (_claimQueue.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public Queue<Claim> GetClaims()
        {
            return _claimQueue;
        }
        public Queue<Claim> GetNextClaim()
        {
            return _claimQueue;
        }
        public bool DeleteClaim()
        {
            int startingCount = _claimQueue.Count;
            _claimQueue.Dequeue();
            bool wasDeleted = (_claimQueue.Count < startingCount) ? true : false;
            return wasDeleted;
        }
    }
}
