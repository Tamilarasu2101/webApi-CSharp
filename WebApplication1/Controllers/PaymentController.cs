using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class PaymentController : Connection
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        //Create a Payment
        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody] CreatePayment value)
        {
            var query = "insert into [dbo].[Payment] (CheckNum, CustomerID, PaymentDate, Amount) values(@CheckNum, @CustomerID, @PaymentDate, @Amount)";
            SqlCommand insertCmd = new SqlCommand(query, con);
            insertCmd.Parameters.AddWithValue("@CheckNum", value.CheckNum);
            insertCmd.Parameters.AddWithValue("@CustomerID", value.CustomerId);
            insertCmd.Parameters.AddWithValue("@PaymentDate", value.PaymentDate);
            insertCmd.Parameters.AddWithValue("@Amount", value.Amount);
            con.Open();
            int result = insertCmd.ExecuteNonQuery();
            if (result > 0)
            {
                return "inserted";
            }
            else
            {
                return "Failed";
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}