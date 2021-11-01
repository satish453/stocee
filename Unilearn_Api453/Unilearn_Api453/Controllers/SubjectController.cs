using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data.SqlClient;
using Unilearn_Api453.Models;


namespace Unilearn_Api453.Controllers
{
    public class SubjectController : ApiController
    {
        

        public HttpResponseMessage Get()
        {
            string query = @"
               select SubjectId,SubjectName from
               dbo.Subject453
               ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["UnilearnDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        public string Post(SubjectController sub)
        {
            try
            {
                string query = @"
                insert into dbo.Subject453 values
                 ('"+SubjectName+@"')
                  ";
            else
            {

            }
        }
    }
}
