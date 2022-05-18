using KCM.Data.Common.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCM.UI.Models
{
    public class TabStripModel
    {
        public TabStripModel()
        {

            Customers = new List<CustomerModel>();
            Orders = new List<OrderModels>();
            Products = new List<ProductModels>();

        }


        public List<CustomerModel> Customers { get; set; }

        public List<ProductModels> Products { get; set; }
        public List<OrderModels> Orders { get; set; }
    }
}
