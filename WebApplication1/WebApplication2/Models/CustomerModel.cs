using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class CustomerModel
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public string DateofBirth { get; set; }
        public string Occupation { get; set; }
        public int?  DeathAmount { get; set; }
        public IEnumerable<SelectListItem> ListOccupation { get; set; }
        public double DeathPremium { get; set; }
        public string SuccessMessage { get; set;}

   }
    public static class OccupationValue
    {
        public const string Cleaner = "Light Manual";
        public const string Doctor = "Professional";
        public const string Author = "White Collar";
        public const string Farmer = "Heavy Manual";
        public const string Mechanic = "Heavy Manual";
        public const string Florist = "Light Manual";
    }

    public static class OccupationText
    {
        public const string Cleaner = "Cleaner";
        public const string Doctor = "Doctor";
        public const string Author = "Author";
        public const string Farmer = "Farmer";
        public const string Mechanic = "Mechanic";
        public const string Florist = "Florist";
    }
}