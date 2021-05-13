using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CustomerController : Connection
    {
        // GET api/<controller>
        public IEnumerable<Customer> Get()
        {
            DataTable _dt = new DataTable();
            var query = "select * from Customer";
            adapter = new SqlDataAdapter { 
            SelectCommand=new SqlCommand(query,con)
            };
            adapter.Fill(_dt);
            List<Customer> customer = new List<Customer>();
            if (_dt.Rows.Count > 0)
            {
                foreach(DataRow customerrecord in _dt.Rows)
                {
                    customer.Add(new ReadCustomer(customerrecord));
                }
            }
            return customer;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody] CreateCustomer value)
        {
            var query = "insert into [dbo].[Customer] (ID, salesRepEmployeeNum, Name, LastName, FirstName, Phone, Address1, Address2, City, State, PostalCode, Country, CreditLimit) values (@ID, @salesRepEmployeeNum, @Name, @LastName, @FirstName, @Phone, @Address1, @Address2, @City, @State, @PostalCode, @Country, @CreditLimit)";
            SqlCommand insertCmd = new SqlCommand(query, con);
            insertCmd.Parameters.AddWithValue("@ID", value.id);
            insertCmd.Parameters.AddWithValue("@salesRepEmployeeNum", value.salesRepEmployeeNum);
            insertCmd.Parameters.AddWithValue("@Name", value.Name);
            insertCmd.Parameters.AddWithValue("@LastName", value.LastName);
            insertCmd.Parameters.AddWithValue("@FirstName", value.FirstName);
            insertCmd.Parameters.AddWithValue("@Phone", value.Phone);
            insertCmd.Parameters.AddWithValue("@Address1", value.Address1);
            insertCmd.Parameters.AddWithValue("@Address2", value.Address2);
            insertCmd.Parameters.AddWithValue("@City", value.City);
            insertCmd.Parameters.AddWithValue("@State", value.State);
            insertCmd.Parameters.AddWithValue("@PostalCode", value.Postalcode);
            insertCmd.Parameters.AddWithValue("@Country", value.Country);
            insertCmd.Parameters.AddWithValue("@CreditLimit", value.CreditLimit);
            con.Open();
            var result = insertCmd.ExecuteNonQuery();
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
        public string Put(int id, [FromBody] CreateCustomer value)
        {
            var query = "update [dbo].[Customer] set salesRepEmployeeNum=@salesRepEmployeeNum, Name=@Name, LastName=@LastName, FirstName=@FirstName, Phone=@Phone, Address1=@Address1, Address2=@Address2, City=@City, State=@State, PostalCode=@PostalCode, Country=@Country, CreditLimit=@CreditLimit where id="+id;
            SqlCommand insertCmd = new SqlCommand(query, con);
            insertCmd.Parameters.AddWithValue("@salesRepEmployeeNum", value.salesRepEmployeeNum);
            insertCmd.Parameters.AddWithValue("@Name", value.Name);
            insertCmd.Parameters.AddWithValue("@LastName", value.LastName);
            insertCmd.Parameters.AddWithValue("@FirstName", value.FirstName);
            insertCmd.Parameters.AddWithValue("@Phone", value.Phone);
            insertCmd.Parameters.AddWithValue("@Address1", value.Address1);
            insertCmd.Parameters.AddWithValue("@Address2", value.Address2);
            insertCmd.Parameters.AddWithValue("@City", value.City);
            insertCmd.Parameters.AddWithValue("@State", value.State);
            insertCmd.Parameters.AddWithValue("@PostalCode", value.Postalcode);
            insertCmd.Parameters.AddWithValue("@Country", value.Country);
            insertCmd.Parameters.AddWithValue("@CreditLimit", value.CreditLimit);
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
            con.Close();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}