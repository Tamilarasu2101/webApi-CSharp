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
    public class EmployeeController : Connection
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

        // POST api/<controller>
        public string Post([FromBody] CreateEmployee value)
        {
            var query = "insert into [dbo].[Employee] (ID, OfficeCode, reportsTo, LastName, FirstName, Extension, Email, JobTitle) values(@ID, @OfficeCode, @reportsTo, @LastName, @FirstName, @Extension, @Email, @JobTitle)";
            SqlCommand insertCmd = new SqlCommand(query, con);
            insertCmd.Parameters.AddWithValue("@ID", value.Id);
            insertCmd.Parameters.AddWithValue("@OfficeCode", value.OfficeCode);
            insertCmd.Parameters.AddWithValue("@reportsTo", value.reportsTo);
            insertCmd.Parameters.AddWithValue("@LastName", value.LastName);
            insertCmd.Parameters.AddWithValue("@FirstName", value.FirstName);
            insertCmd.Parameters.AddWithValue("@Extension", value.Extension);
            insertCmd.Parameters.AddWithValue("@Email", value.Email);
            insertCmd.Parameters.AddWithValue("@JobTitle", value.JobTitle);
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
        public string Put(int id, [FromBody] CreateEmployee value)
        {
            var query = "update [dbo].[Employee] set OfficeCode=@OfficeCode, reportsTo=@reportsTo, LastName=@LastName, FirstName=@FirstName, Extension=@Extension, Email=@Email, JobTitle=@JobTitle";
            SqlCommand insertCmd = new SqlCommand(query, con);
            insertCmd.Parameters.AddWithValue("@ID", value.Id);
            insertCmd.Parameters.AddWithValue("@OfficeCode", value.OfficeCode);
            insertCmd.Parameters.AddWithValue("@reportsTo", value.reportsTo);
            insertCmd.Parameters.AddWithValue("@LastName", value.LastName);
            insertCmd.Parameters.AddWithValue("@FirstName", value.FirstName);
            insertCmd.Parameters.AddWithValue("@Extension", value.Extension);
            insertCmd.Parameters.AddWithValue("@Email", value.Email);
            insertCmd.Parameters.AddWithValue("@JobTitle", value.JobTitle);
            con.Open();
            int result = insertCmd.ExecuteNonQuery();
            if (result > 0)
            {
                return "updated";
            }
            else
            {
                return "Failed";
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}