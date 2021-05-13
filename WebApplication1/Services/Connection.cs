using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Services
{
    public class Connection:ApiController
    {
        protected SqlConnection con = new SqlConnection("Server=DESKTOP-JE4BQAC;Database=OrderDatabase;Trusted_Connection=True;");
        protected SqlDataAdapter adapter;
    }
}