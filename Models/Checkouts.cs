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
    public class Checkouts
    {
        public int CheckoutID { get; set; }

        public int CheckoutTime { get; set; }

        public int IsCheckin { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public int ItemID { get; set; }
    }
}
