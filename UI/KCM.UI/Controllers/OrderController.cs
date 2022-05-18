using KCM.Data.Common.EntityFramework;
using KCM.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KCM.UI.Controllers
{
    public class OrderController : Controller
    {
        KCMEntities dBContext = new KCMEntities();
        
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCustomerList()
        {
            return Json(dBContext.Customers.Select(c => new { CustomerId = c.CustomerId, CustomerName = c.CustomerName }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductList()
        {
            return Json(dBContext.Products.Select(s => new { ProductId = s.ProductId, Name = s.Name }), JsonRequestBehavior.AllowGet);

        }
        //public JsonResult Cascading_Get_Customers()
        //{


        //    return Json(dBContext.Customers.Select(c => new { CustomerId = c.CustomerId, CustomerName = c.CustomerName }), JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult Template_GetCustomers()
        //{
        //    var customers = new KCMEntities().Customers.Select(customer => new CustomerViewModel
        //    {
        //        CustomerId = customer.CustomerId,
        //        CustomerName = customer.CustomerName,
        //        //ContactName = customer.ContactName,
        //        //ContactTitle = customer.ContactTitle,
        //        //Address = customer.Address,
        //        //City = customer.City,
        //        //Region = customer.Region,
        //        //PostalCode = customer.PostalCode,
        //        //Country = customer.Country,
        //        //Phone = customer.Phone,
        //        //Fax = customer.Fax,
        //        //Bool = customer.Bool
        //    });

        //    return Json(customers, JsonRequestBehavior.AllowGet);
        //}
    }


}
