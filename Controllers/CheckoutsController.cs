﻿using Microsoft.AspNetCore.Http;
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
    public class CheckoutsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CheckoutsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {

            string query = @"SELECT Checkouts.CheckoutID,Checkouts.CheckoutTime,Checkouts.IsCheckin,Items.ItemID,Items.ItemName,Users.UserID,Users.Name
                            FROM dbo.checkouts
	                            inner join dbo.Items 
		                            ON Items.ItemID=checkouts.ItemID
	                            inner join dbo.Users 
	                    	        ON Users.UserID=Checkouts.UserID
                                outer join dbo.Checkins
                                    ON Checkins.CheckinID= Checkouts.CheckinID
                                            ";

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
        public JsonResult Post(Checkouts checkout)
        {

            string query = @"insert into dbo.checkouts
			(UserID,ItemID,Ischeckin)
		       values (@UserID,@ItemID,@Ischeckin)
                                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UserID", checkout.UserID);
                    myCommand.Parameters.AddWithValue("@ItemID", checkout.ItemID);
                    myCommand.Parameters.AddWithValue("@IsCheckin", 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Checkouts checkout)
        {

            string query = @"update dbo.Items
                            set UserID = @UserID
                            where CheckoutID= @CheckoutID
                                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CheckoutID", checkout.CheckoutID);
                    myCommand.Parameters.AddWithValue("@UserID", checkout.UserID);
                    myCommand.Parameters.AddWithValue("@ItemID", checkout.ItemID);
                    myCommand.Parameters.AddWithValue("@IsCheckin", checkout.IsCheckin);

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

            string query = @"delete from dbo.Checkouts
                            where CheckoutID= @CheckoutID
                                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CheckoutID", id);
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
