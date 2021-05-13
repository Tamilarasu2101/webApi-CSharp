using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Customer
    {
        public int id { get; set; }
        public int salesRepEmployeeNum { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Postalcode { get; set; }
        public string Country { get; set; }
        public float CreditLimit { get; set; }
    }

    public class CreateCustomer : Customer
    {

    }

    public class ReadCustomer : Customer
    {
        public ReadCustomer(DataRow row)
        {
            id = Convert.ToInt32(row["ID"]);
            salesRepEmpNum = Convert.ToInt32(row["SalesRepEmployeeNum"]);
            Name = row["Name"].ToString();
            LastName = row["LastName"].ToString();
            FirstName = row["FirstName"].ToString();
            Phone= row["Phone"].ToString();
            Address1 = row["Address1"].ToString();
            Address2 = row["Address2"].ToString();
            City = row["City"].ToString();
            State = row["State"].ToString();
            Country = row["Country"].ToString();
            CreditLimit = Convert.ToInt32(row["CreditLimit"]);
        }
        public int id { get; set; }
        public int salesRepEmpNum { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Postalcode { get; set; }
        public string Country { get; set; }
        public float CreditLimit { get; set; }
    }
}