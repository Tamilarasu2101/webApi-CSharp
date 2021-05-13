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
    public class OfficeController : Connection
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
        //Create Office
        // POST api/<controller>
        public string Post([FromBody] CreateOffice value)
        {
            var query = "insert into [dbo].[Office] (Code, City, Phone, Address1, Address2, State, Country, PostalCode, Territory) values(@Code, @City, @Phone, @Address1, @Address2, @State, @Country, @PostalCode, @Territory)";
            SqlCommand insertCmd = new SqlCommand(query, con);
            insertCmd.Parameters.AddWithValue("@Code", value.Code);
            insertCmd.Parameters.AddWithValue("@Phone", value.Phone);
            insertCmd.Parameters.AddWithValue("@City", value.City);
            insertCmd.Parameters.AddWithValue("@Address1", value.Address1);
            insertCmd.Parameters.AddWithValue("@Address2", value.Address2);
            insertCmd.Parameters.AddWithValue("@State", value.State);
            insertCmd.Parameters.AddWithValue("@Country", value.Country);
            insertCmd.Parameters.AddWithValue("@PostalCode", value.PostalCode);
            insertCmd.Parameters.AddWithValue("@Territory", value.Territory);
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
        public string Put(int id, [FromBody] CreateOffice value)
        {
            var query = "update [dbo].[Office] set City=@City, Phone=@Phone, Address1=@Address1, Address2=@Address2, State=@State, Country=@Country, PostalCode=@PostalCode, Territory=@Territory where Code="+id;
            SqlCommand insertCmd = new SqlCommand(query, con);
            insertCmd.Parameters.AddWithValue("@Phone", value.Phone);
            insertCmd.Parameters.AddWithValue("@City", value.City);
            insertCmd.Parameters.AddWithValue("@Address1", value.Address1);
            insertCmd.Parameters.AddWithValue("@Address2", value.Address2);
            insertCmd.Parameters.AddWithValue("@State", value.State);
            insertCmd.Parameters.AddWithValue("@Country", value.Country);
            insertCmd.Parameters.AddWithValue("@PostalCode", value.PostalCode);
            insertCmd.Parameters.AddWithValue("@Territory", value.Territory);
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