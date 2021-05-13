using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class OrderProductController : Connection
    {
        // GET api/<controller>
        public IEnumerable<OrderProduct> Get()
        {
            DataTable _dt = new DataTable();
            var query = "select * from OrderProduct";
            adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            adapter.Fill(_dt);
            List<OrderProduct> product = new List<OrderProduct>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow productrecord in _dt.Rows)
                {
                    product.Add(new ReadOrderProduct(productrecord));
                }
            }

            return product;
        }

        // GET api/<controller>/5
        //Get Products by orderid
        [HttpGet]
        public Product Get(int id)
        {
            var query = "select * from Product as p inner join Order_Product as o on p.Code=o.ProductCode where o.ID=@id";
            SqlCommand selectCmd = new SqlCommand(query, con);
            selectCmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader dataReader = selectCmd.ExecuteReader();
            Product pro = new Product();
            while (dataReader.Read())
            {
                pro.Code = Convert.ToInt32(dataReader["Code"]);
                pro.ProductlineId = Convert.ToInt32(dataReader["ProductlineID"]);
                pro.Name = Convert.ToString(dataReader["Name"]);
                pro.Scale = Convert.ToInt32(dataReader["Scale"]);
                pro.Vendor = Convert.ToString(dataReader["Vendor"]);
                pro.PdtDescription = Convert.ToString(dataReader["PdtDescription"]);
                pro.QtyInStock = Convert.ToInt32(dataReader["QtyInStock"]);
                pro.BuyPrice = Convert.ToInt32(dataReader["BuyPrice"]);
                pro.MSRP = Convert.ToInt32(dataReader["MSRP"]);
            }
            con.Close();
            return pro;
        }

        //Get Products by customerid
        [HttpGet]
        public Product Get(string id)
        {
            var query = "select * from Product join Order_Product on Product.Code=Order_Product.ProductCode join [dbo].[Order] on Order_Product.OrderID=[dbo].[Order].ID where [dbo].[Order].CustomerID=@id";
            SqlCommand selectCmd = new SqlCommand(query, con);
            selectCmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader dataReader = selectCmd.ExecuteReader();
            Product pro = new Product();
            while (dataReader.Read())
            {
                pro.Code = Convert.ToInt32(dataReader["Code"]);
                pro.ProductlineId = Convert.ToInt32(dataReader["ProductlineID"]);
                pro.Name = Convert.ToString(dataReader["Name"]);
                pro.Scale = Convert.ToInt32(dataReader["Scale"]);
                pro.Vendor = Convert.ToString(dataReader["Vendor"]);
                pro.PdtDescription = Convert.ToString(dataReader["PdtDescription"]);
                pro.QtyInStock = Convert.ToInt32(dataReader["QtyInStock"]);
                pro.BuyPrice = Convert.ToInt32(dataReader["BuyPrice"]);
                pro.MSRP = Convert.ToInt32(dataReader["MSRP"]);
            }
            con.Close();
            return pro;
        }
        // POST api/<controller>
        public void Post([FromBody] string value)
        {
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