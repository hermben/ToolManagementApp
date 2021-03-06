using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ToolManagementApp.Models;

namespace ToolManagementApp.Entity
{
    public class ItemsEntity
    {
        string GetAllQuery = @"SELECT Items.ItemTypeID, ItemTypes.ItemTypeName,Items.ItemName, Items.ItemID, Items.ItemSerial,Items.ItemDescription,Items.IsCheckout 
            FROM dbo.Items inner join dbo.ItemTypes ON ItemTypes.ItemTypeID = Items.ItemTypeID";


        string GetAvailableQuery = @"SELECT Items.ItemTypeID, ItemTypes.ItemTypeName,Items.ItemName, Items.ItemID, Items.ItemSerial,Items.ItemDescription,Items.IsCheckout 
            FROM dbo.Items inner join dbo.ItemTypes ON ItemTypes.ItemTypeID = Items.ItemTypeID
            WHERE IsCheckout = 0";

        string PostQuery = @"insert into dbo.Items
                                    (ItemName,ItemSerial,ItemDescription,IsCheckout,ItemTypeID)
                            values (@ItemName,@ItemSerial,@ItemDescription,@IsCheckout,@ItemTypeID)
                                ";

        string PutQuery = @"update dbo.Items
                             set ItemName = @ItemName,
                                ItemSerial=@ItemSerial,
                                ItemDescription=@ItemDescription,
                                IsCheckout=@IsCheckout,
                                ItemTypeID=@ItemTypeID
                            where ItemID= @ItemID
                                ";

        string DeleteQuery = @"delete from dbo.Items
                            where ItemID= @ItemID
                                ";


        private readonly IConfiguration _configuration;

        public ItemsEntity(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataTable GetAll()
        {
            DataTable table = new DataTable();
            string sqlDataSource = this._configuration.GetConnectionString("datatoolDB");
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
        public DataTable GetAvailable()
        {
            DataTable table = new DataTable();
            string sqlDataSource = this._configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(GetAvailableQuery, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return table;
        }

        public DataTable Post(Items item)
        {
            DataTable table = new DataTable();
            string sqlDataSource = this._configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(PostQuery, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ItemName", item.ItemName);
                    myCommand.Parameters.AddWithValue("@ItemSerial", item.ItemSerial);
                    myCommand.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);
                    myCommand.Parameters.AddWithValue("@IsCheckout", item.IsCheckout);
                    myCommand.Parameters.AddWithValue("@ItemTypeID", item.ItemTypeID);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return table;
        }

        public DataTable Put(Items item)
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("datatoolDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(PutQuery, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ItemID", item.ItemID);
                    myCommand.Parameters.AddWithValue("@ItemName", item.ItemName);
                    myCommand.Parameters.AddWithValue("@ItemSerial", item.ItemSerial);
                    myCommand.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);
                    myCommand.Parameters.AddWithValue("@IsCheckout", item.IsCheckout);
                    myCommand.Parameters.AddWithValue("@ItemTypeID", item.ItemTypeID);
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
