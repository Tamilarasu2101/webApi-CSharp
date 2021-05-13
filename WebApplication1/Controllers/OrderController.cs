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
    public class OrderController : Connection
    {
        // GET api/<controller>
        //Get All Orders
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            DataTable _dt = new DataTable();
            var query = "select * from [dbo].[Order]";
            adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            adapter.Fill(_dt);
            List<Order> order = new List<Order>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow orderrecord in _dt.Rows)
                {
                    order.Add(new ReadOrder(orderrecord));
                }
            }

            return order;
        }

        // GET api/<controller>/5
        //Get order by Id
        [HttpGet]
        public IEnumerable<Order> Get(int id)
        {
            DataTable _dt = new DataTable();
            var query = "select * from [dbo].[Order] where ID=" + id;
            adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            adapter.Fill(_dt);
            List<Order> order = new List<Order>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow orderrecord in _dt.Rows)
                {
                    order.Add(new ReadOrder(orderrecord));
                }
            }

            return order;
        }

        //Get order by Customer Id
        [HttpGet]
        public IEnumerable<Order> Get(string cid)
        {
            DataTable _dt = new DataTable();
            var query = "select * from [dbo].[Order] where CustomerID=" + cid;
            adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            adapter.Fill(_dt);
            List<Order> order = new List<Order>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow orderrecord in _dt.Rows)
                {
                    order.Add(new ReadOrder(orderrecord));
                }
            }

            return order;
        }

        // POST api/<controller>
        public string Post([FromBody] Order value)
        {
            var query = "insert into [dbo].[Order] (ID, CustomerID, OrderDate, RequiredDate, ShippedDate, Status, Comments) values(@ID, @CustomerID, @OrderDate, @RequiredDate, @ShippedDate, @Status, @Comments)";
            SqlCommand insertCmd = new SqlCommand(query, con);
            insertCmd.Parameters.AddWithValue("@ID", value.Id);
            insertCmd.Parameters.AddWithValue("@CustomerID", value.CustomerId);
            insertCmd.Parameters.AddWithValue("@OrderDate", value.OrderDate);
            insertCmd.Parameters.AddWithValue("@RequiredDate", value.RequiredDate);
            insertCmd.Parameters.AddWithValue("@ShippedDate", value.ShippedDate);
            insertCmd.Parameters.AddWithValue("@Status", value.Status);
            insertCmd.Parameters.AddWithValue("@Comments", value.Comments);
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
        //Update Order
        // PUT api/<controller>/5
        public string Put(int id, [FromBody] CreateOrder value)
        {
            var query = "update [dbo].[Order] set CustomerID=@CustomerID, OrderDate=@OrderDate, RequiredDate=@RequiredDate, ShippedDate=@ShippedDate, Status=@Status, Comments=@Comments where ID="+id;
            SqlCommand insertCmd = new SqlCommand(query, con);
            insertCmd.Parameters.AddWithValue("@CustomerID", value.CustomerId);
            insertCmd.Parameters.AddWithValue("@OrderDate", value.OrderDate);
            insertCmd.Parameters.AddWithValue("@RequiredDate", value.RequiredDate);
            insertCmd.Parameters.AddWithValue("@ShippedDate", value.ShippedDate);
            insertCmd.Parameters.AddWithValue("@Status", value.Status);
            insertCmd.Parameters.AddWithValue("@Comments", value.Comments);
            con.Open();
            var result = insertCmd.ExecuteNonQuery();
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