using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ToolManagementApp.Models;

namespace ToolManagementApp.Models
{
    public class ItemTypes
    {
        public int itemTypeID { get; set; }

        public string itemTypeName { get; set; }

    }
}
