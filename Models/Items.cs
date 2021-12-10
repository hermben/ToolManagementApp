using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolManagementApp.Models
{
    public class Items
    {

        public int ItemID { get; set; }

        public string ItemName { get; set; }

        public string ItemSerial { get; set; }

        public string ItemDescription { get; set; }

        public Boolean IsCheckout { get; set; }

    }
}
