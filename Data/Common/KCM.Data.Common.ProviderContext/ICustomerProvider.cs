using KCM.Data.Common.DataModels.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCM.Data.Common.ProviderContext
{
    public interface ICustomerProvider
    {

        GetCustomerResponse GetCustomers(GetCustomerRequest req);
        
        

        AddCustomerResponse AddCustomer(AddCustomerRequest req);

        UpDateCustomerResponse UpDateCustomer(UpDateCustomerRequest req);

        DeleteCustomerResponse DeleteCustomer(DeleteCustomerRequest req);

        GetCustomerOrderResponse GetCustomerOrder(GetCustomerOrderRequest req);
        IsActiveResponse IsActive_Save(IsActiveRequest req);

    }
}
