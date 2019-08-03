using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    [Table("CustomerTraining")]
    public class CustomerTrainings
    {
        public int Id { get; set; }
        public string TrainingName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int DateTimeDifference { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }


    }    
}