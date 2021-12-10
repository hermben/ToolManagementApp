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
    public class SubItems
    {
        public int subItemID { get; set; }

        public string subItemName { get; set; }

        public string subItemDescription { get; set; }

      
    }
}
