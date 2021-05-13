using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int OfficeCode { get; set; }
        public int reportsTo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
    }
    public class CreateEmployee : Employee
    {

    }
    public class ReadEmployee : Employee
    {

    }
}