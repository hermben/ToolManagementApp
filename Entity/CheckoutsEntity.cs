using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ToolManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToolManagementApp.Entity
{
    public class CheckoutsEntity
    {

        string GetAllQuery = @"SELECT Checkouts.CheckoutID,Checkouts.CheckoutTime,Checkouts.IsCheckin,Items.ItemID,Items.ItemName,Users.UserID,Users.Name, Checkins.CheckinTime,Checkins.UserSignature
                            FROM dbo.checkouts
	                            inner join dbo.Items 
		                            ON Items.ItemID=checkouts.ItemID
	                            inner join dbo.Users 
	                    	        ON Users.UserID=Checkouts.UserID
                                LEFT JOIN dbo.Checkins
                                    ON Checkouts.CheckoutID = Checkins.CheckoutID";


        string PostQuery = @"insert into dbo.checkouts
			(UserID,ItemID,Ischeckin)
		       values (@UserID,@ItemID,@Ischeckin)";


        string PutQuery =  @"update dbo.Items
                            set UserID = @UserID
                            where CheckoutID = @CheckoutID ";

        string DeleteQuery = @"delete from dbo.Checkouts
                            where CheckoutID= @CheckoutID
                                ";

        private readonly IConfiguration _configuration;

        public CheckoutsEntity(IConfiguration configuration)
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

        public DataTable Post(Checkouts checkout)

        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(PostQuery, myCon))
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
            return table;
        }

        public DataTable Put(Checkouts checkout)
        {

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(PutQuery, myCon))
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
                    myCommand.Parameters.AddWithValue("@CheckoutID", id);
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
