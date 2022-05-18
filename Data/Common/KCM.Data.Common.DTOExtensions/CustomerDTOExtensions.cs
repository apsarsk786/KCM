using KCM.Data.Common.DataModels;
using KCM.Data.Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KCM.Data.Common.DTOExtensions
{
    public static class CustomerProvider
    {
        public static List<CustomerModel> ToCustomerModels(this List<Customer> forms)
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            foreach (var item in forms)
            {
                CustomerModel customer = new CustomerModel();
                customer.CustomerId = item.CustomerId;
                customer.CustomerName = item.CustomerName;
                customer.CustomerAddress = item.CustomerAddress;
                customer.CustomerPhoneNumber = item.CustomerPhoneNumber;
                customer.CustomerEmail = item.CustomerEmail;
                customer.IsActive = item.IsActive;
                customers.Add(customer);

            }

            return customers;

        }
        public static List<Customer> ToCustomers(this List<CustomerModel> form)
        {
            List<Customer> customers = new List<Customer>();
            foreach (var item in form)
            {
                Customer customer = new Customer();
                customer.CustomerId = item.CustomerId;
                customer.CustomerName = item.CustomerName;
                customer.CustomerAddress = item.CustomerAddress;
                customer.CustomerPhoneNumber = item.CustomerPhoneNumber;
                customer.CustomerEmail = item.CustomerEmail;
                customer.IsActive = item.IsActive;
                customers.Add(customer);

            }

            return customers;
        }
        public static CustomerModel ToCustomerModel(this Customer from)
        {
            CustomerModel customer = new CustomerModel();
            customer.CustomerId = from.CustomerId;
            customer.CustomerName = from.CustomerName;
            customer.CustomerEmail = from.CustomerEmail;
            customer.CustomerPhoneNumber = from.CustomerPhoneNumber;
            customer.CustomerAddress = from.CustomerAddress;
            customer.IsActive = from.IsActive;
            return customer;
        }
        public static Customer ToCustomer(this CustomerModel form)
        {
            Customer customer = new Customer();
            customer.CustomerId = form.CustomerId;
            customer.CustomerName = form.CustomerName;
            customer.CustomerPhoneNumber = form.CustomerPhoneNumber;
            customer.CustomerAddress = form.CustomerAddress;
            customer.CustomerEmail = form.CustomerEmail;
            customer.IsActive = form.IsActive;
            return customer;
        }
        
        public static ProductModels ToProductModel(this Product form)
        {
            ProductModels product = new ProductModels();
            product.ProductId = form.ProductId;
            product.Name = form.Name;
            product.Description = form.Description;
            return product;
        }
        public static OrderModels ToOrderModel(this Order form)
        {
            OrderModels order = new OrderModels();
            order.OrderId = form.OrderId;
            return order;
        }
      



    }
}

