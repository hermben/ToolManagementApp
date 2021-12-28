using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ToolManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ToolManagementApp.Entity
{
    public class UsersEntity
    {


        string GetAllQuery = @"select UserID, Name, Email, password, Address,
                            RegistrationDate,IsAdmin,PhotoFileName from dbo.Users";


        string PostQuery = @"insert into dbo.Users
                             (Name,Email, password,Address,RegistrationDate,IsAdmin,PhotoFileName)
                          values(@Name,@Email, @Password,@Address,@RegistrationDate,@IsAdmin,@PhotoFileName)";


       
                 string PutQuery = @"update dbo.Users
                            set Name = @Name,
                                Email= @Email,
                                Password= @Password,
                                Address= @Address,
                                RegistrationDate= @RegistrationDate,
                                IsAdmin= @IsAdmin,
                                PhotoFileName= @PhotoFileName
                            where UserID = @UserID
                                ";

        string DeleteQuery = @"delete from dbo.Users
                            where UserID= @UserID
                                ";


        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public object Request { get; private set; }

        public UsersEntity(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        public DataTable GetAll()
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(GetAllQuery, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return table;
        }

        public DataTable Post(Users user)
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(PostQuery, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Name", user.name);
                    myCommand.Parameters.AddWithValue("@Email", user.email);
                    myCommand.Parameters.AddWithValue("@Password", user.password);
                    myCommand.Parameters.AddWithValue("@Address", user.address);
                    myCommand.Parameters.AddWithValue("@RegistrationDate", user.registrationDate);
                    myCommand.Parameters.AddWithValue("@IsAdmin", user.isAdmin);
                    myCommand.Parameters.AddWithValue("@PhotoFileName", user.photofilename);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return table;
        }
        public DataTable Put(Users user)
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(PutQuery, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UserID", user.userID);
                    myCommand.Parameters.AddWithValue("@Name", user.name);
                    myCommand.Parameters.AddWithValue("@Email", user.email);
                    myCommand.Parameters.AddWithValue("@Password", user.password);
                    myCommand.Parameters.AddWithValue("@Address", user.address);
                    myCommand.Parameters.AddWithValue("@RegistrationDate", user.registrationDate);
                    myCommand.Parameters.AddWithValue("@IsAdmin", user.isAdmin);
                    myCommand.Parameters.AddWithValue("@PhotoFileName", user.photofilename);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return table;
        }

        public DataTable Delete(int id)
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(DeleteQuery, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UserID", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return table;
        }

    }
}
