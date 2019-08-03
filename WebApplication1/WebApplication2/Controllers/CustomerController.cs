using System;
using System.Collections.Generic;
using WebApplication2.Models;
using WebApplication2.Services;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerService _customerService { get; set; }
        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            CustomerTrainings model = new CustomerTrainings();
            return View(model);
        }

       
        [HttpPost]
        public ActionResult Index(CustomerTrainings model, string btnValue)
        {
            _customerService = new CustomerService();
            if (model != null)
            {
                if (model.StartDate != null && model.EndDate != null)
                    model.DateTimeDifference = Convert.ToInt32((model.EndDate - model.StartDate).Value.TotalDays);
                else
                    model.DateTimeDifference = 0;
                if (model.StartDate > model.EndDate)
                    model.ErrorMessage = _customerService.Message(false, model.DateTimeDifference, model.StartDate.Value, model.EndDate.Value);
                if (model.ErrorMessage == "")
                {
                    var isValid = _customerService.InsertCustomerTraining(model);
                    model.SuccessMessage = _customerService.Message(isValid, model.DateTimeDifference, model.StartDate.Value, model.EndDate.Value);
                }
            } 
            return View(model);
        }

    }
}