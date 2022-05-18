using KCM.Data.Common.DataModels.ReqResp;
using KCM.Data.Common.ProviderContext;
using KCM.UI.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KCM.UI.Controllers
{
    public class CustOperaionsController : Controller
    {
        ICustomerProvider _customerProvider;
        IProductProvider _productProvider;
       
        // GET: CustOperaions
      public CustOperaionsController(ICustomerProvider customerProvider,IProductProvider productProvider)
        {
            _customerProvider = customerProvider;
            _productProvider = productProvider;
            
        }
        [HttpPost]
        public ActionResult TabStripModel()
        {
            TabStripModel tabStrip = new TabStripModel();
            tabStrip.Customers = (_customerProvider.GetCustomers(new GetCustomerRequest())).Customers;
            tabStrip.Products = (_productProvider.GetProduct(new ProductReqResp.GetProductRequest())).Products;

            return View(tabStrip);
        }
    }
}