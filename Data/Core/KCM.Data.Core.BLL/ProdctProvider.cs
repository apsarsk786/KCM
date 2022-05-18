using KCM.Data.Common.EntityFramework;
using KCM.Data.Common.ProviderContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCM.Data.Common.DataModels.ReqResp;
using static KCM.Data.Common.DataModels.ReqResp.ProductReqResp;
using KCM.Data.Common.DTOExtensions;
using KCM.Data.Common.DataModels;

namespace KCM.Data.Core.BLL
{
    public class  ProdctProvider: IProductProvider
    {
        KCMEntities dbContext = new KCMEntities();

        public GetProductResponse GetProduct(GetProductRequest req)
        {

            GetProductResponse resp = new GetProductResponse();
            
            resp.Products = dbContext.Products.ToList().ToProductModels();
            return resp;


        }
        public List<ProductModels> GetProduct()
        {
            var products = dbContext.Products.ToList().ToProductModels();
            return products;
        }
        public ProductModels GetProduct(int productId)
        {
            var product = dbContext.Products.ToList().ToProductModels().Where(s=>s.ProductId==productId).FirstOrDefault();
            return product;
        }
   
  

        //public AddProductResponse AddProduct(AddProductRequest req)
        //{
        //    AddProductResponse resp = new AddProductResponse();
        //    var product = req.Products.ToProduct();
        //    dbContext.Products.Add(product);
        //    dbContext.SaveChanges();
        //    resp.IsSuccess = product.ProductId > 0;
        //    return resp;

        //}

        public AddProductResponse AddProduct(AddProductRequest req)
        {
            AddProductResponse resp = new AddProductResponse();
            var product = req.Products.ToProduct();
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            resp.IsSuccess = product.ProductId > 0;
            return resp;
        }

        //public AddProductResponse AddProduct(AddProductResponse req)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
