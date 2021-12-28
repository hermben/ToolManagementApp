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
    public class SubItemsEntity
    {

        string GetAllQuery = @"select SubItemID, SubItemName,SubItemDescription from dbo.SubItems";


        string PostQuery = @"insert into dbo.Items
                            values (@SubItemName)
                                ";

        string PutQuery = @"update dbo.Items
                            set SubItemName = @SubItemName,
                                SubItemDescription=@SubItemDescription
                            where ItemID= @ItemID
                                ";

        string DeleteQuery = @"delete from dbo.Items
                            where ItemID= @ItemID
                                ";

        private readonly IConfiguration _configuration;

        public SubItemsEntity(IConfiguration configuration)
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

        public DataTable Post(SubItems subitem)
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(PostQuery, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ItemName", subitem.subItemName);
                    myCommand.Parameters.AddWithValue("@ItemName", subitem.subItemDescription);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return table;
        }

        public DataTable Put(SubItems subitem)
        {

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(PutQuery, myCon))
                {
                    myCommand.Parameters.AddWithValue("@SubItemID", subitem.subItemID);
                    myCommand.Parameters.AddWithValue("@SubItemName", subitem.subItemName);
                    myCommand.Parameters.AddWithValue("@SubItemName", subitem.subItemDescription);
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
                    myCommand.Parameters.AddWithValue("@ItemID", id);
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
