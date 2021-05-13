using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OrderDate { get; set; }
        public string RequiredDate { get; set; }
        public string ShippedDate { get; set; }
        public int Status { get; set; }
        public string Comments { get; set; }
    }

    public class CreateOrder : Order
    {

    }
    public class ReadOrder : Order
    {
        public ReadOrder(DataRow row)
        {
            Id = Convert.ToInt32(row["ID"]);
            CustomerId = Convert.ToInt32(row["CustomerID"]);
            OrderDate = row["OrderDate"].ToString();
            RequiredDate = row["RequiredDate"].ToString();
            ShippedDate = row["ShippedDate"].ToString();
            Status = Convert.ToInt32(row["Status"]);
            Comments = row["Comments"].ToString();
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OrderDate { get; set; }
        public string RequiredDate { get; set; }
        public string ShippedDate { get; set; }
        public int Status { get; set; }
        public string Comments { get; set; }
    }
}