using KCM.Data.Common.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCM.UI.Models
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            OrderModels = new List<OrderModels>();
        }
        public CustomerModel Customer { get; set; }
        public List<OrderModels> OrderModels { get; set; }


    }
}