using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public enum ClaimType { Car, Home, Theft}
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }
        public Claim(int claimID, ClaimType claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

        //public void DateVerification()
        //{
        //    Claim claim = new Claim();
        //    bool thinking = true;
        //    while (thinking)
        //    {
        //        var dateFormats = new[] { "mm/dd/yyyy" };
        //        bool isValid = false;

        //        Console.WriteLine("Enter date of incedent: (mm/dd/yyyy)");
        //        string dateInput = Console.ReadLine();

        //        foreach (string dateFormat in dateFormats)
        //        {
        //            DateTime dateToUse;
        //            if (DateTime.TryParse(dateInput, out dateToUse))
        //            {
        //                claim.DateOfIncident = dateToUse;
        //                isValid = true;
        //            }
        //        }
        //        if (isValid == true)
        //        {
        //            thinking = false;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Ivalid");
        //        }

        //    }
        //}
    }
}
