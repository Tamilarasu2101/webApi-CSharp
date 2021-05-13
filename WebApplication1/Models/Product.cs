﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Code { get; set; }
        public int ProductlineId { get; set; }
        public string Name { get; set; }
        public int Scale { get; set; }
        public string Vendor { get; set; }
        public string PdtDescription { get; set; }
        public int QtyInStock { get; set; }
        public int BuyPrice { get; set; }
        public int MSRP { get; set; }
    }
    public class CreateProduct : Product
    {

    }
    public class ReadProduct : Product
    {
        public ReadProduct(DataRow row)
        {
            Code = Convert.ToInt32(row["Code"]);
            ProductlineId = Convert.ToInt32(row["ProductlineID"]);
            Name = row["Name"].ToString();
            Scale = Convert.ToInt32(row["Scale"]);
            Vendor = row["Vendor"].ToString();
            PdtDescription = row["PdtDescription"].ToString();
            QtyInStock=Convert.ToInt32(row["QtyInStock"]);
            BuyPrice = Convert.ToInt32(row["BuyPrice"]);
            MSRP = Convert.ToInt32(row["MSRP"]);
        }
        public int Code { get; set; }
        public int ProductlineId { get; set; }
        public string Name { get; set; }
        public int Scale { get; set; }
        public string Vendor { get; set; }
        public string PdtDescription { get; set; }
        public int QtyInStock { get; set; }
        public int BuyPrice { get; set; }
        public int MSRP { get; set; }
    }
}