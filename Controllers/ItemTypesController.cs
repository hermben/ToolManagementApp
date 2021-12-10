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
    public class ItemTypesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ItemTypesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {

            string query = @"select ItemTypesID, ItemTypesName from dbo.SubItems";

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
        public JsonResult Post(ItemTypes itemtype)
        {

            string query = @"insert into dbo.ItemTypes
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
                    myCommand.Parameters.AddWithValue("@ItemTypeName", itemtype.itemTypeName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(ItemTypes itemtype)
        {

            string query = @"update dbo.Items
                            set SubItemName = @SubItemName
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
                    myCommand.Parameters.AddWithValue("@SubItemID", itemtype.itemTypeID);
                    myCommand.Parameters.AddWithValue("@SubItemName", itemtype.itemTypeName);
                    
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
                    myCommand.Parameters.AddWithValue("@ItemTypeID", id);
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
