using KCM.Data.Common.DataModels;
using KCM.Data.Common.ProviderContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ubiety.Dns.Core;
using static KCM.Data.Common.DataModels.ReqResp.ProductReqResp;

namespace KCM.UI.Controllers
{
    public class ProductController : Controller
    {
        IProductProvider _productProvider;
        public ProductController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = _productProvider.GetProduct(new GetProductRequest()).Products;

            return View(products);
        }
        public ActionResult AddProduct()
        {
            ProductModels products = new ProductModels();

            return View("AddProduct",products);
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModels product)
        {
           
            var response = _productProvider.AddProduct(new AddProductRequest { Products = product });
            TempData["StatusMessage"] = response.IsSuccess ? "Customer create Success" : "Something error";

            return RedirectToAction("Index", product);
        }
    }
}