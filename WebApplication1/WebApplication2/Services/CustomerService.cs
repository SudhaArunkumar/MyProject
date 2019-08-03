using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class CustomerService
    {
        private string MessageText; 
        public bool InsertCustomerTraining(CustomerTrainings model)
        {
            bool isValid = false;
            try
            { 
                if (model != null)
                {
                    SqlConnection conn = new SqlConnection("@Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Arunkumar\\documents\\visual studio 2015\\Projects\\WebApplication1\\WebApplication2\\App_Data\\DatabaseLocal.mdf;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("Insert into CustomerTraining (TrainingName,StartDate,EndDate,DateDifference) values('" + model.TrainingName + "','" + model.StartDate + "','" + model.EndDate + "','" + model.DateTimeDifference + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    isValid= true;
                }
            }
            catch(Exception ex)
            {
                isValid = false;
                throw ex;
            }
            return isValid;
        }       

        public string Message(bool Isvalid,int Days,DateTime startDate,DateTime endDate)
        {
            if(startDate > endDate)
            {
                MessageText = "StartDate should not be greater than EndDate.";
            }
               
            if (Isvalid)
                MessageText = string.Format("Successfully Inserted Date Difference {0}", Days);
            else
                MessageText = "UnSuccessfull Insert Data";

            return MessageText;
        }
    }
}