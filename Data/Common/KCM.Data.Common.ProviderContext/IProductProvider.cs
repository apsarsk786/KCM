using KCM.Data.Common.DataModels.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KCM.Data.Common.DataModels.ReqResp.ProductReqResp;

namespace KCM.Data.Common.ProviderContext
{
     public interface IProductProvider
    {
        GetProductResponse GetProduct(GetProductRequest req);

        AddProductResponse AddProduct(AddProductRequest req);

    }
}
