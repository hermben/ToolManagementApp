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
    public class Checkins
    {

        public int checkinID { get; set; }

        public int checkinTime { get; set; }
        public string  userSignature {get; set; }

        public string checkoutID { get; set; }

        public string UserID { get; set; }
    }
}
