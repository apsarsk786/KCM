using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCM.Data.Common.DataModels.ReqResp
{
    public class ProductReqResp
    {
        public class GetProductRequest
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

        }
        public class GetProductResponse
        {
            public GetProductResponse()
            {
                Products = new List<ProductModels>();

            }
            public List<ProductModels> Products { get; set; }
        }
        public class AddProductRequest
        {
           public int ProductId { get; set; }

            public ProductModels Products { get; set; }
        }
        public class AddProductResponse
        {
            public bool IsSuccess { get; set; }
            public string StatusMessage { get; set; }
        }
    }
}