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
using ToolManagementApp.Entity;

namespace ToolManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private ItemsEntity itemEntity;
        public ItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
           itemEntity = new ItemsEntity(configuration);
        }

        [HttpGet]
        public JsonResult Get()
        {

            //string query = @"select ItemID, ItemName, ItemSerial, ItemDescription, ischeckout from dbo.Items";
            //string query = @"SELECT Items.ItemTypeID, ItemTypes.ItemTypeName,Items.ItemName, Items.ItemID, Items.ItemSerial,Items.ItemDescription,Items.IsCheckout 
            //FROM dbo.Items inner join dbo.ItemTypes ON ItemTypes.ItemTypeID = Items.ItemTypeID";

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
            var items = this.itemEntity.GetAll();
            return new JsonResult(items);
        }

        [HttpPost]
        public JsonResult Post(Items item)
        {

            //string query = @"insert into dbo.Items
            //                        (ItemName,ItemSerial,ItemDescription,IsCheckout,ItemTypeID)
            //                values (@ItemName,@ItemSerial,@ItemDescription,@IsCheckout,@ItemTypeID)
            //                    ";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("@ItemName", item.ItemName);
            //        myCommand.Parameters.AddWithValue("@ItemSerial", item.ItemSerial);
            //        myCommand.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);
            //        myCommand.Parameters.AddWithValue("@IsCheckout", item.IsCheckout);
            //        myCommand.Parameters.AddWithValue("@ItemTypeID", item.ItemTypeID);
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult("Added Successfully");
            this.itemEntity.Post(item);
            return new JsonResult("Posted Successfully");
        }

        [HttpPut]
        public JsonResult Put(Items item)
        {

            //string query = @"update dbo.Items
            //                 set ItemName = @ItemName,
            //                    ItemSerial=@ItemSerial,
            //                    ItemDescription=@ItemDescription,
            //                    IsCheckout=@IsCheckout,
            //                    ItemTypeID=@ItemTypeID
            //                where ItemID= @ItemID
            //                    ";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("@ItemID", item.ItemID);
            //        myCommand.Parameters.AddWithValue("@ItemName", item.ItemName);
            //        myCommand.Parameters.AddWithValue("@ItemSerial", item.ItemSerial);
            //        myCommand.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);
            //        myCommand.Parameters.AddWithValue("@IsCheckout", item.IsCheckout);
            //        myCommand.Parameters.AddWithValue("@ItemTypeID", item.ItemTypeID);
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult("Updated Successfully");
            this.itemEntity.Put(item);
            return new JsonResult("Posted Successfully");
        }

        [HttpDelete ("{id}")]
        public JsonResult Delete (int id)
        {

            //string query = @"delete from dbo.Items
            //                where ItemID= @ItemID
            //                    ";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("@ItemID",id);

            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult("successfully deleted");
            this.itemEntity.Delete(id);
            return new JsonResult("Posted Successfully");


        }
    }
}
