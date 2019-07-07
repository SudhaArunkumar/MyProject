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
            var model = new CustomerModel();
            var customerModel = LoadDropDown(model);
            return View(customerModel);
        }

        private CustomerModel LoadDropDown(CustomerModel model)
        {
            ModelState.Clear();
            model.ListOccupation = GetListofOccupationDropDown();
            return model;
        }

        [HttpPost]
        public ActionResult Index(CustomerModel model, string btnValue)
        {
            _customerService = new CustomerService();
            if (model != null)
            {
                model.DeathPremium = _customerService.CalculationForDeathPremium(model);
                if (model.DeathPremium != 0)
                {
                    model.SuccessMessage = string.Format("{0} Yearly Premium Amount is {1}", model.Name, model.DeathPremium);
                    model.ListOccupation = GetListofOccupationDropDown();
                    model.Occupation = GetListofOccupationDropDown().Where(x => x.Value == model.Occupation).ToString();
                }
            } 
            return View(model);
        }

        private IEnumerable<SelectListItem> GetListofOccupationDropDown()
        {
            List<SelectListItem> listOccupation = new List<SelectListItem>();
            listOccupation.Add(new SelectListItem { Text = "--Seclect Occupation", Value = "" });
            listOccupation.Add(new SelectListItem { Text = OccupationText.Cleaner, Value = OccupationValue.Cleaner });
            listOccupation.Add(new SelectListItem { Text = OccupationText.Doctor, Value = OccupationValue.Doctor });
            listOccupation.Add(new SelectListItem { Text = OccupationText.Author, Value = OccupationValue.Author });
            listOccupation.Add(new SelectListItem { Text = OccupationText.Farmer, Value = OccupationValue.Farmer });
            listOccupation.Add(new SelectListItem { Text = OccupationText.Mechanic, Value = OccupationValue.Mechanic });
            listOccupation.Add(new SelectListItem { Text = OccupationText.Florist, Value = OccupationValue.Florist });

            return listOccupation;
        }
    }
}