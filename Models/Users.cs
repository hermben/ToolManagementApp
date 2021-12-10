using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolManagementApp.Models
{
    public class Users
    {
        public int userID { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string address { get; set; }

        public string registrationDate { get; set; }

        public Boolean isAdmin { get; set; }
    }
}
