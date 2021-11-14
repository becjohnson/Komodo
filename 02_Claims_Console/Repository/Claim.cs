using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console.Repository
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class Claim
    {
        public Claim() { }
        public Claim(int id, ClaimType claimType, string description, decimal amount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            Id = id;
            ClaimType = claimType;
            Description = description;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
            Amount = amount;
        }
        public int Id { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
    }
}
