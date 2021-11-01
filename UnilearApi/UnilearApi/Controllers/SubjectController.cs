using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UnilearApi.Models;


namespace UnilearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SubjectController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                  select SubjectId,SubjectName from dbo.Subject453
               ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TeacherAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon=new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query,myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);


        }
        [HttpPost]
        public JsonResult post(Subject sub)
        {
            string query = @"
              insert into dbo.subject453 values
               ('"+sub.SubjectName+@"')
              ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TeacherAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");


        }
        [HttpPut]
        public JsonResult put(Subject sub)
        {
            string query = @"
                         update dbo.Subject453 set
                         SubjectName='" + sub.SubjectName + @"' 
                         where SubjectId=" + sub.SubjectId + @"
                         ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TeacherAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon=new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand=new SqlCommand(query,myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully!");


        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                   delete from dbo.Subject453
                   where SubjectId=" + id + @"
                   ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TeacherAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Delete Succefully");
        }

    }
}
