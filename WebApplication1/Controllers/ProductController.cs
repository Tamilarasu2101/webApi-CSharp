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
    public class ProductController : Connection
    {
        // GET api/<controller>
        //Get All Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            DataTable _dt = new DataTable();
            var query = "select * from [dbo].[Product]";
            adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            adapter.Fill(_dt);
            List<Product> product = new List<Product>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow productrecord in _dt.Rows)
                {
                    product.Add(new ReadProduct(productrecord));
                }
            }

            return product;
        }

        // GET api/<controller>/5
        //Get Products with Code
        [HttpGet]
        public IEnumerable<Product> Get(int id)
        {
            DataTable _dt = new DataTable();
            var query = "select * from [dbo].[Product] where Code=" + id;
            adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            adapter.Fill(_dt);
            List<Product> product = new List<Product>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow productrecord in _dt.Rows)
                {
                    product.Add(new ReadProduct(productrecord));
                }
            }

            return product;
        }

        //Get Products with Name
        [HttpGet]
        public IEnumerable<Product> Get(string name)
        {
            //DataTable _dt = new DataTable();
            //var query = "select * from [dbo].[Product] where Name="+name;
            //SqlCommand selectCmd = new SqlCommand(query, con);
            //selectCmd.Parameters.AddWithValue("@name", name);
            //con.Open();
            //adapter = new SqlDataAdapter
            //{
            //    SelectCommand = new SqlCommand(query, con)
            //};
            //adapter.Fill(_dt);
            //List<Product> product = new List<Product>(_dt.Rows.Count);
            //if (_dt.Rows.Count > 0)
            //{
            //    foreach (DataRow productrecord in _dt.Rows)
            //    {
            //        product.Add(new ReadProduct(productrecord));
            //    }
            //}
            //con.Close();
            //return product;
            List<Product> products = new List<Product>();
            var query = "select * from Product where Name=@name";
            SqlCommand selectCmd = new SqlCommand(query, con);
            selectCmd.Parameters.AddWithValue("@name", name);
            con.Open();
            SqlDataReader dataReader = selectCmd.ExecuteReader();
            Product product = new Product();
            while (dataReader.Read())
            {
                product.Code = Convert.ToInt32(dataReader["Code"]);
                product.ProductlineId = Convert.ToInt32(dataReader["ProductlineId"]);
                product.Name = Convert.ToString(dataReader["Name"]);
                product.Scale = Convert.ToInt32(dataReader["Scale"]);
                product.Vendor = Convert.ToString(dataReader["Vendor"]);
                product.PdtDescription = Convert.ToString(dataReader["PdtDescription"]);
                product.QtyInStock = Convert.ToInt32(dataReader["QtyInStock"]);
                product.BuyPrice = Convert.ToInt32(dataReader["BuyPrice"]);
                product.MSRP = Convert.ToInt32(dataReader["MSRP"]);
                products.Add(product);
            }
            con.Close();
            return products;
        }

        //Create Product
        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody] CreateProduct value)
        {
            var query = "insert into [dbo].[Product] (Code, ProductlineID, Name, Scale, Vendor, PdtDescription, QtyInStock, BuyPrice, MSRP) values(@Code, @ProductlineID, @Name, @Scale, @Vendor, @PdtDescription, @QtyInStock, @BuyPrice, @MSRP)";
            SqlCommand insertCmd = new SqlCommand(query, con);
            insertCmd.Parameters.AddWithValue("@Code", value.Code);
            insertCmd.Parameters.AddWithValue("@ProductlineID", value.ProductlineId);
            insertCmd.Parameters.AddWithValue("@Name", value.Name);
            insertCmd.Parameters.AddWithValue("@Scale", value.Scale);
            insertCmd.Parameters.AddWithValue("@Vendor", value.Vendor);
            insertCmd.Parameters.AddWithValue("@PdtDescription", value.PdtDescription);
            insertCmd.Parameters.AddWithValue("@QtyInStock", value.QtyInStock);
            insertCmd.Parameters.AddWithValue("@BuyPrice", value.BuyPrice);
            insertCmd.Parameters.AddWithValue("@MSRP", value.MSRP);
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

        //Update Product
        // PUT api/<controller>/5
        [HttpPut]
        public string Put(int id, [FromBody]CreateProduct value)
        {
            var query = "update [dbo].[Product] set ProductlineID=@ProductlineID, Name=@Name, Scale=@Scale, Vendor=@Vendor, PdtDescription=@PdtDescription, QtyInStock=@QtyInStock, BuyPrice=@BuyPrice, MSRP=@MSRP where Code="+id;
            SqlCommand insertCmd = new SqlCommand(query, con);
            insertCmd.Parameters.AddWithValue("@ProductlineID", value.ProductlineId);
            insertCmd.Parameters.AddWithValue("@Name", value.Name);
            insertCmd.Parameters.AddWithValue("@Scale", value.Scale);
            insertCmd.Parameters.AddWithValue("@Vendor", value.Vendor);
            insertCmd.Parameters.AddWithValue("@PdtDescription", value.PdtDescription);
            insertCmd.Parameters.AddWithValue("@QtyInStock", value.QtyInStock);
            insertCmd.Parameters.AddWithValue("@BuyPrice", value.BuyPrice);
            insertCmd.Parameters.AddWithValue("@MSRP", value.MSRP);
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