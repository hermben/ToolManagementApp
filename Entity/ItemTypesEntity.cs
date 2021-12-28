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
    public class ItemTypesEntity
    {



        string GetAllQuery = @"select ItemTypeID, ItemTypeName from dbo.ItemTypes";

        string PostQuery = @"insert into dbo.ItemTypes
                                  values(@ItemTypeName)
                                ";


        string PutQuery = @"update dbo.ItemTypes
                            set ItemTypeName = @ItemTypeName
                            where ItemTypeID= @ItemTypeID
                                ";

        string DeleteQuery = @"delete from dbo.ItemTypes
                            where ItemTypeID= @ItemTypeID
                                ";



        private readonly IConfiguration _configuration;

        public ItemTypesEntity(IConfiguration configuration)
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


        public DataTable Post(ItemTypes itemtyp)
        {

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(PostQuery, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ItemTypeName", itemtyp.itemTypeName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return table;
        }

        public DataTable Put(ItemTypes itemtype)
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(PutQuery, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ItemTypeID", itemtype.itemTypeID);
                    myCommand.Parameters.AddWithValue("@ItemTypeName", itemtype.itemTypeName);

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
                    myCommand.Parameters.AddWithValue("@ItemTypeID", id);
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
