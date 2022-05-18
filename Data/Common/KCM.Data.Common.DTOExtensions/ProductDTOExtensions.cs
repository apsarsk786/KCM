using KCM.Data.Common.DataModels;
using KCM.Data.Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCM.Data.Common.DTOExtensions
{
    public static class ProductDTOExtensions
    {
      
        public static List<ProductModels> ToProductModels(this List<Product> form)
        {
            List<ProductModels> product = new List<ProductModels>();
            foreach (var item in form)
            {
                ProductModels pro = new ProductModels();

                pro.ProductId = item.ProductId;
                pro.Name = item.Name;
                pro.ProductId = item.ProductId;
                pro.Description = item.Description;
                product.Add(pro);

            }
            return product;
        }
        public static List<Product> ToProduct(this List<ProductModels> form)
        {
            List<Product> products = new List<Product>();
            foreach (var item in products) 
            {
                Product product = new Product();
                product.ProductId = item.ProductId;
                product.Name = item.Name;
                product.Description = item.Description;
                products.Add(product);


            }
            return products;



        }
        public static ProductModels ToProductModels(this Product Form)
        {
            ProductModels productModels = new ProductModels();
            productModels.ProductId = Form.ProductId;
            productModels.Name = Form.Name;
            productModels.Description = Form.Description;
            return productModels;
        }
        public static Product ToProduct(this ProductModels Form)
        {
            Product product = new Product();
            product.ProductId = Form.ProductId;
            product.Name = Form.Name;
            product.Description = Form.Description;
            return product;
        }
        

    }
}