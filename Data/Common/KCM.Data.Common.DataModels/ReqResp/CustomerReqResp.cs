
using KCM.Data.Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCM.Data.Common.DataModels.ReqResp
{
    public class GetCustomerRequest
    {
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

    }
    public class GetCustomerResponse
    {
        public GetCustomerResponse()
        {
            Customers = new List<CustomerModel>();
           
        }
        public List<CustomerModel> Customers { get; set; }
  

    }
    public class UpDateCustomerRequest
    {
        public CustomerModel Customer { get; set; }
    }
    public class UpDateCustomerResponse
    {
        public bool IsSuccess { get; set; }
        public string StatusMessage { get; set; }
    }
    public class AddCustomerRequest
    {
        public CustomerModel Customer { get; set; }
    }
    public class AddCustomerResponse
    {
        public bool IsSuccess { get; set; }
        public string StatusMessage { get; set; }
    }
    public class GetCustomerOrderRequest
    {
        public int? CustomerId { get; set; }
    }
    public class GetCustomerOrderResponse
    {
      
        public List<OrderModels> CustomerOrder;

        public GetCustomerOrderResponse()
        {
            CustomerOrders=new List<OrderModels>();
        }
        public List<OrderModels> CustomerOrders { get; set; }

    }
    public class DeleteCustomerRequest
    {
        public CustomerModel Customer { get; set; }
    }
    public class DeleteCustomerResponse
    {
        public bool IsSuccess { get; set; }
        public string StatusMessage { get; set; }
    }
    public class DetailsRequest
    {
        public CustomerModel Customer { get; set; }
    }
    public class DetailsResponse
    {
        public bool IsSuccess { get; set; }
        public string StatusMessage { get; set; }
    }
    public class IsActiveRequest
    {
        public CustomerModel Customer { get; set; }
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }
    }
    public class IsActiveResponse
    {
        public bool IsSuccess { get; set; }
        public string StatusMessage { get; set; }
    }
}