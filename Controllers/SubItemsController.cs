using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ToolManagementApp.Models;

namespace ToolManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SubItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {

            string query = @"select SubItemID, SubItemName,SubItemDescription from dbo.SubItems";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
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

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(SubItems subitem)
        {

            string query = @"insert into dbo.Items
                            values (@SubItemName)
                                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ItemName", subitem.subItemName);
                    myCommand.Parameters.AddWithValue("@ItemName", subitem.subItemDescription);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(SubItems subitem)
        {

            string query = @"update dbo.Items
                            set SubItemName = @SubItemName,
                                SubItemDescription=@SubItemDescription
                            where ItemID= @ItemID
                                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@SubItemID", subitem.subItemID);
                    myCommand.Parameters.AddWithValue("@SubItemName",subitem.subItemName);
                    myCommand.Parameters.AddWithValue("@SubItemName", subitem.subItemDescription);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            string query = @"delete from dbo.Items
                            where ItemID= @ItemID
                                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ItemID", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("successfully deleted");
        }
    }
}
