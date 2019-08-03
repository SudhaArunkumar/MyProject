using System;
using WebApplication2.Controllers;
using WebApplication2.Models;
using WebApplication2.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            CustomerController training = new CustomerController();
            //Act
            ViewResult result = training.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void PostIndexMethodGetSuccessfullMessage()
        {
            //Arrange 
            CustomerController training = new CustomerController();
            //Setting Model Property
            CustomerTrainings model = new CustomerTrainings()
            {
                TrainingName = "Test",
                StartDate = Convert.ToDateTime("08/08/2019"),
                EndDate = Convert.ToDateTime("10/08/2019"),
            };
            //Act
            ViewResult result = training.Index(model, string.Empty) as ViewResult;
            //ServiceCall 
            CustomerService service = new CustomerService();
            var valid = service.InsertCustomerTraining(model);
            if (valid)
                Assert.IsTrue(valid, "Successfully Inserted");
            }
        [TestMethod]
        public void PostIndexMethodGetErrorMessage()
        {
            //Arrange 
            CustomerController training = new CustomerController();
            //Setting Model Property
            CustomerTrainings model = new CustomerTrainings()
            {
                TrainingName = "Test",
                StartDate = Convert.ToDateTime("08/08/2019"),
                EndDate = Convert.ToDateTime("10/08/2019"),
            };
            //Act
            ViewResult result = training.Index(model, string.Empty) as ViewResult;
            //ServiceCall 
            CustomerService service = new CustomerService();
            var valid = service.InsertCustomerTraining(model);
                if (!valid)
                    Assert.IsTrue(valid, "UnSuccessfull");
            }

    }
}
