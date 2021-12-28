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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using ToolManagementApp.Entity;

namespace ToolManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTypesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private ItemTypesEntity itemTypesEntity;

        public object ItemTypesEntity { get; private set; }

        public ItemTypesController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
            itemTypesEntity = new ItemTypesEntity(configuration);
        }

        [HttpGet]
        public JsonResult Get()
        {

            //string GetAllQuery = @"select ItemTypeID, ItemTypeName from dbo.ItemTypes";

            //string query = @"select ItemTypeID, ItemTypeName from dbo.ItemTypes";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult(table);
            var ItemTypes = this.itemTypesEntity.GetAll();
            return new JsonResult(ItemTypes);
        }

        [HttpPost]
        public JsonResult Post(ItemTypes itemtyp)
        {

            //string query = @"insert into dbo.ItemTypes
            //                      values(@ItemTypeName)
            //                    ";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("@ItemTypeName", itemtyp.itemTypeName);
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult("Added Successfully");
            this.itemTypesEntity.Post(itemtyp);
            return new JsonResult("Posted Successfully");
        }

        [HttpPut]
        public JsonResult Put(ItemTypes itemtype)
        {

            //string query = @"update dbo.ItemTypes
            //                set ItemTypeName = @ItemTypeName
            //                where ItemTypeID= @ItemTypeID
            //                    ";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("@ItemTypeID", itemtype.itemTypeID);
            //        myCommand.Parameters.AddWithValue("@ItemTypeName", itemtype.itemTypeName);

            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult("Updated Successfully");
            this.itemTypesEntity.Put(itemtype);
            return new JsonResult("Posted Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            //string query = @"delete from dbo.ItemTypes
            //                where ItemTypeID= @ItemTypeID
            //                    ";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("@ItemTypeID", id);
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult("successfully deleted");
            this.itemTypesEntity.Delete(id);
            return new JsonResult("Posted Successfully");
        }
    }
}
