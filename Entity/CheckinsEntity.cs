using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ToolManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToolManagementApp.Entity
{
    public class CheckinsEntity
    {
        string GetAllQuery = @"select CheckinID, CheckinTime,UserSignature,CheckoutID,UserName, UserEmail from dbo.Checkins";


        string PostQuery = @"insert into dbo.Checkins
                                    (UserSignature,CheckoutID,UserName, UserEmail)
                            values (@UserSignature,@CheckoutID,@UserName, @UserEmail)
                                ";
        string PutQuery = @"update dbo.Checkins
                             set UserSignature = @UserSignature
                            where CheckinID= @CheckinID
                                ";

        string DeleteQuery = @"delete from dbo.Checkins
                            where CheckinID= @CheckinID
                                ";

        private readonly IConfiguration _configuration;

        public CheckinsEntity(IConfiguration configuration)
        {
            _configuration = configuration;
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



            public DataTable Post(Checkins checkin)
            {
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(PostQuery, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@UserSignature",checkin.userSignature);
                        myCommand.Parameters.AddWithValue("@CheckoutID", checkin.checkoutID);
                        myCommand.Parameters.AddWithValue("@UserName", checkin.UserName);
                        myCommand.Parameters.AddWithValue("@UserEmail", checkin.UserEmail);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }

                return table;
            }

        public DataTable Put(Checkins checkin)
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(PutQuery, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CheckinID", checkin.checkinID);
                    myCommand.Parameters.AddWithValue("@UserSignature", checkin.userSignature);
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
                    myCommand.Parameters.AddWithValue("@CheckinID", id);
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

