using KCM.Data.Common.DataModels;
using KCM.Data.Common.DataModels.ReqResp;
using KCM.Data.Common.DTOExtensions;
using KCM.Data.Common.EntityFramework;
using KCM.Data.Common.ProviderContext;
using LinqKit;
using LinqKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace KCM.Data.Core.BLL
{
    public class CustomerProvider : ICustomerProvider
    {
        KCMEntities dbContext = new KCMEntities();
        public GetCustomerResponse GetCustomers(GetCustomerRequest req)
       {

            GetCustomerResponse resp = new GetCustomerResponse();
            var customers = dbContext.Customers.ToList().ToCustomerModels();
            // return resp;

            if (customers != null && customers.Any())
            {
                resp.Customers = customers;
            }
            return resp;

        }

        public AddCustomerResponse AddCustomer(AddCustomerRequest req )
        {
            AddCustomerResponse resp = new AddCustomerResponse();
            var customer = req.Customer.ToCustomer();
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            resp.IsSuccess = customer.CustomerId > 0;
            return resp;
        
        }

        public GetCustomerResponse GetCustomerOrder(GetCustomerRequest req)
        {
            GetCustomerResponse resp = new GetCustomerResponse();
            var customer = resp.Customers.ToCustomers();
            dbContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
            return resp;

        }

       //public updatecustomerresponse updatecustomer(updatecustomerrequest req)
       // {
       //     updatecustomerresponse resp = new updatecustomerresponse();
       //     var customer = req.customer.tocustomer();
       //     dbcontext.entry(customer).state = system.data.entity.entitystate.modified;
       //     dbcontext.savechanges();
       //     return resp;

       // }

        public GetCustomerResponse GetCustomer(GetCustomerRequest req)
        {
            var predicate = PredicateBuilder.New<Customer>(true);
            if (req.CustomerId.HasValue)
            {
                predicate = predicate.And(s => s.CustomerId == req.CustomerId);
            }
            if (!string.IsNullOrEmpty(req.CustomerName))
            {
                predicate = predicate.And(s => s.CustomerName == req.CustomerName);

                
            }
            if (!string.IsNullOrEmpty(req.CustomerEmail))
            {
                predicate = predicate.And(s => s.CustomerEmail == req.CustomerEmail);
            }
            GetCustomerResponse resp = new GetCustomerResponse();
            var customers = dbContext.Customers.AsExpandable().ToList().ToCustomerModels();
            return resp;

        }

        public DeleteCustomerResponse DeleteCustomer(DeleteCustomerRequest req)
        {
            DeleteCustomerResponse resp = new DeleteCustomerResponse();
            var customer = req.Customer.ToCustomer();
            dbContext.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
            return resp;
        }

        public UpDateCustomerResponse UpDateCustomer(UpDateCustomerRequest req)
        {
            UpDateCustomerResponse resp = new UpDateCustomerResponse();
            var customer = req.Customer.ToCustomer();
            dbContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
            return resp;
        }

        public DetailsResponse Details(DetailsRequest req)
        {
            DetailsResponse resp = new DetailsResponse();
            var customer = req.Customer.ToCustomer();
            dbContext.Entry(customer).State = System.Data.Entity.EntityState.Unchanged;
            return resp;
        }
     

        public GetCustomerOrderResponse GetCustomerOrder(GetCustomerOrderRequest req)
        {
            GetCustomerOrderResponse resp = new GetCustomerOrderResponse();
            var customerOrders = (from orders in dbContext.Orders
                                  join customer in dbContext.Customers on orders.CustomerId equals customer.CustomerId
                                  join product in dbContext.Products on orders.ProductId equals product.ProductId
                                  where customer.CustomerId == req.CustomerId
                                  select new OrderModels()
                                  {
                                      CustomerId = customer.CustomerId,
                                      CustomerName = customer.CustomerName,
                                      ProductId = product.ProductId,
                                      ProductName = product.Name,
                                      OrderId = orders.OrderId
                                  }).ToList();


            resp.CustomerOrder = customerOrders;
            return resp;

        }

        //public UpDateCustomerResponse UpdateCustomer(UpDateCustomerRequest req)
        //{

        //    updatecustomerresponse resp = new updatecustomerresponse();
        //    var customer = req.customer.tocustomer();
        //    dbcontext.entry(customer).state = system.data.entity.entitystate.modified;
        //    dbcontext.savechanges();
        //    return resp;
        //}

        public GetCustomerOrderResponse GetCustomerOrders(GetCustomerOrderRequest req)
        {
            throw new NotImplementedException();
        }

        public IsActiveResponse IsActive_Save(IsActiveRequest req)
        {
            IsActiveResponse response = new IsActiveResponse();
            var customer = dbContext.Customers.Find(req.CustomerId);
            customer.IsActive = req.IsActive;
            dbContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
            return response;




        }
    }


}