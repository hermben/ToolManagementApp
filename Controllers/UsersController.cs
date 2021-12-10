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
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {

            string query = @"select UserID, Name, Email, password, Address, RegistrationDate, IsAdmin from dbo.Users";

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
        public JsonResult Post(Users user)
        {

            string query = @"insert into dbo.Users
                             (Name,Email, password,Address,RegistrationDate,IsAdmin)
                          values(@Name,@Email, @Password,@Address,@RegistrationDate,@IsAdmin)
                                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ItemName", user.name);
                    myCommand.Parameters.AddWithValue("@Email", user.email);
                    myCommand.Parameters.AddWithValue("@Password", user.password);
                    myCommand.Parameters.AddWithValue("@Address", user.address);
                    myCommand.Parameters.AddWithValue("@RegistrationDate", user.registrationDate);
                    myCommand.Parameters.AddWithValue("@IsAdmin", user.registrationDate);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Users user)
        {

            string query = @"update dbo.Users
                            set Name = @Name,
                                Email=@Email,
                                Password=@Password,
                                Address=@Address,
                                RegistrationDate=@RegistrationDate,
                                IsAdmin=@IsAdmin
                            where UserID= @UserID
                                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UserID", user.userID);
                    myCommand.Parameters.AddWithValue("@Name", user.name);
                    myCommand.Parameters.AddWithValue("@Email", user.email);
                    myCommand.Parameters.AddWithValue("@Password", user.password);
                    myCommand.Parameters.AddWithValue("@Address", user.address);
                    myCommand.Parameters.AddWithValue("@RegistrationDate", user.registrationDate);
                    myCommand.Parameters.AddWithValue("@IsAdmin", user.isAdmin);
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

            string query = @"delete from dbo.Users
                            where UserID= @UserID
                                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UserID", id);

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


