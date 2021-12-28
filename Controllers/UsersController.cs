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
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private UsersEntity usersEntity;
        public UsersController(IConfiguration configuration,IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
            usersEntity = new UsersEntity(configuration,env);
        }

        [HttpGet]
        public JsonResult Get()
        {

            //string query = @"select UserID, Name, Email, password, Address,
            //                RegistrationDate,IsAdmin,PhotoFileName from dbo.Users";

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

            var users = this.usersEntity.GetAll();
            return new JsonResult(users);

        }

        [HttpPost]
        public JsonResult Post(Users user)
        {

            //string query = @"insert into dbo.Users
            //                 (Name,Email, password,Address,RegistrationDate,IsAdmin,PhotoFileName)
            //              values(@Name,@Email, @Password,@Address,@RegistrationDate,@IsAdmin,@PhotoFileName)
            //                    ";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("@Name", user.name);
            //        myCommand.Parameters.AddWithValue("@Email", user.email);
            //        myCommand.Parameters.AddWithValue("@Password", user.password);
            //        myCommand.Parameters.AddWithValue("@Address", user.address);
            //        myCommand.Parameters.AddWithValue("@RegistrationDate", user.registrationDate);
            //        myCommand.Parameters.AddWithValue("@IsAdmin", user.isAdmin);
            //        myCommand.Parameters.AddWithValue("@PhotoFileName", user.photofilename);
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult("Added Successfully");
          this.usersEntity.Post(user);
            return new JsonResult("Posted Successfully");
        }

        [HttpPut]
        public JsonResult Put(Users user)
        {

            //string query = @"update dbo.Users
            //                set Name = @Name,
            //                    Email=@Email,
            //                    Password=@Password,
            //                    Address=@Address,
            //                    RegistrationDate=@RegistrationDate,
            //                    IsAdmin=@IsAdmin,
            //                    PhotoFileName=@PhotoFileName
            //                where UserID= @UserID
            //                    ";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("@UserID", user.userID);
            //        myCommand.Parameters.AddWithValue("@Name", user.name);
            //        myCommand.Parameters.AddWithValue("@Email", user.email);
            //        myCommand.Parameters.AddWithValue("@Password", user.password);
            //        myCommand.Parameters.AddWithValue("@Address", user.address);
            //        myCommand.Parameters.AddWithValue("@RegistrationDate", user.registrationDate);
            //        myCommand.Parameters.AddWithValue("@IsAdmin", user.isAdmin);
            //        myCommand.Parameters.AddWithValue("@PhotoFileName", user.photofilename);
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult("Updated Successfully");

           this.usersEntity.Put(user);
            return new JsonResult("Posted Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            //string query = @"delete from dbo.Users
            //                where UserID= @UserID
            //                    ";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("@UserID", id);

            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            //return new JsonResult("successfully deleted");

            this.usersEntity.Delete(id);
            return new JsonResult("Posted Successfully");

        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalpath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream=new FileStream(physicalpath, FileMode.Create))
                {

                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);

            }
            catch (Exception)
            {
                return new JsonResult("anonymous.");

            }

        }
    }
}


