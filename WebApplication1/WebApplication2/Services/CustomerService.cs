using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class CustomerService
    {
        public double CalculationForDeathPremium(CustomerModel model)
        {
            double premium = 0;
            if(model != null)
            {
                if( !string.IsNullOrEmpty(model.Name) && (model.Age != 0) 
                    && !string.IsNullOrEmpty(model.DateofBirth) && !string.IsNullOrEmpty(model.Occupation) && (model.DeathAmount != 0))
                {
                    var ratingFactor = GetOccupationRatingFactor(model.Occupation);
                    premium = ((Convert.ToDouble(model.DeathAmount) * ratingFactor * Convert.ToDouble(model.Age)) / 1000 * 12);
                }
            }
            return premium;
        }

        private static class OccupationRatingFactor
        {
            public const double professional = 1.0;
            public const double WhiteCollar = 1.25;
            public const double LightManual = 1.50;
            public const double HeavyManual = 1.75;
        }

        public double GetOccupationRatingFactor(string ocuupationValue)
        {
            double value  = 0;
            switch(ocuupationValue)
            {
                case OccupationValue.Author:
                    value = 1.25;
                    break;

                case OccupationValue.Cleaner:
                    value = 1.50;
                    break;


                case OccupationValue.Doctor:
                    value = 1.0;
                    break;


                case OccupationValue.Farmer:
                    value = 1.75;
                    break;
            }
            return value;
        }
    }
}