using KCM.Data.Common.DataModels.ReqResp;
using KCM.Data.Common.ProviderContext;
using KCM.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KCM.UI.Controllers
{
    public class HomeController : Controller
    {
        ICustomerProvider _customerProvider;
        public HomeController(ICustomerProvider customerProvider)
        {
            _customerProvider = customerProvider;
        }

        public ActionResult Index(int customerId)
        {
            CustomerViewModel model = new CustomerViewModel();
            model.Customer = _customerProvider.GetCustomers(new GetCustomerRequest { CustomerId = customerId }).Customers.FirstOrDefault();
            model.OrderModels = _customerProvider.GetCustomerOrder(new GetCustomerOrderRequest { CustomerId = customerId }).CustomerOrders;


            return View("Index",model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
    }
}