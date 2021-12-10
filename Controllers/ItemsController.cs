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
    public class ItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {

            string query = @"select ItemID, ItemName, ItemSerial, ItemDescription, ischeckout from dbo.Items";

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
        public JsonResult Post(Items item)
        {

            string query = @"insert into dbo.Items
                            values (@ItemName)
                            values (@ItemSerial)
                            values (@ItemDescription)
                                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ItemName", item.ItemName);
                    myCommand.Parameters.AddWithValue("@ItemSerial", item.ItemSerial);
                    myCommand.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);
                    myReader = myCommand.ExecuteReader();
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Items item)
        {

            string query = @"update dbo.Items
                            set ItemName = @ItemName
                            set ItemSerial=@ItemSerial
                            set ItemDescription=@ItemDescription
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
                    myCommand.Parameters.AddWithValue("@ItemID", item.ItemID);
                    myCommand.Parameters.AddWithValue("@ItemName", item.ItemName);
                    myCommand.Parameters.AddWithValue("@ItemSerial", item.ItemSerial);
                    myCommand.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete ("{id}")]
        public JsonResult Delete (int id)
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
                    myCommand.Parameters.AddWithValue("@ItemID",id);
                    
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
