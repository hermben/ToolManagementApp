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
    public class CheckinsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private CheckinsEntity checkinEntity;
        public CheckinsController(IConfiguration configuration)
        {
            _configuration = configuration;
            checkinEntity = new CheckinsEntity(configuration);
        }

        [HttpGet]
        public JsonResult Get()
        {

            //string query = @"select CheckinID, CheckinTime,UserSignature,CheckoutID,UserID from dbo.Checkins";

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
            var checkins = this.checkinEntity.GetAll();
            return new JsonResult(checkins);
        }

        [HttpPost]
        public JsonResult Post(Checkins checkin)
        {

            //string query = @"insert into dbo.Checkins
            //                        (UserSignature,CheckoutID,UserID)
            ////                values (@UserSignature,@CheckoutID,@UserID)
            //                    ";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("@UserSignature", checkin.userSignature);
            //        myCommand.Parameters.AddWithValue("@CheckoutID", checkin.checkoutID);
            //        myCommand.Parameters.AddWithValue("@UserID", checkin.UserID);
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult("Added Successfully");
            this.checkinEntity.Post(checkin);
            return new JsonResult("Posted Successfully");
        }

        [HttpPut]
        public JsonResult Put(Checkins checkin)
        {

            //string query = @"update dbo.Checkins
            //                 set UserSignature = @UserSignature
            //                where CheckinID= @CheckinID
            //                    ";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("@CheckinID", checkin.checkinID);
            //        myCommand.Parameters.AddWithValue("@UserSignature", checkin.userSignature);
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult("Updated Successfully");

            this.checkinEntity.Put(checkin);
            return new JsonResult("Posted Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            string query = @"delete from dbo.Checkins
                            where CheckinID= @CheckinID
                                ";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("@CheckinID", id);
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult("successfully deleted");

            this.checkinEntity.Delete(id);
            return new JsonResult("Posted Successfully");
        }
    }
}
