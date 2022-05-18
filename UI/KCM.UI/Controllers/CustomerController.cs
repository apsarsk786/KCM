using KCM.Data.Common.DataModels;
using KCM.Data.Common.DataModels.ReqResp;
using KCM.Data.Common.ProviderContext;
using KCM.UI.Models;
using System.Linq;
using System.Web.Mvc;

namespace KCM.UI.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerProvider _customerProvider;
        public CustomerController(ICustomerProvider customerProvider)
        {
            _customerProvider = customerProvider;
        }

        // GET: Customer
        public ActionResult Index()
        {
            // ProductModels productModels = new ProductModels();

            var customers = (_customerProvider.GetCustomers(new GetCustomerRequest())).Customers;


            return View("Index", customers);
        }
        public ActionResult Create()
        {
            CustomerModel customer = new CustomerModel();

            return View("Creates", customer);
        }
        [HttpPost]
        public ActionResult Creates(CustomerModel customer)
        {
            var response = _customerProvider.AddCustomer(new AddCustomerRequest() { Customer = customer });
            TempData["StatusMessage"] = response.IsSuccess ? "Customer create Success" : "Something error";

            return RedirectToAction("Index", customer);
        }
        public ActionResult DeleteCustomer(int? customerId)
        {
            var customers = _customerProvider.GetCustomers(new GetCustomerRequest() { CustomerId = customerId }).Customers;
            var customer = customers.Where(s => s.CustomerId == customerId).FirstOrDefault();
            //var customers = _customerProvider.GetCustomers(new GetCustomerRequest() { }).Customers.Where(s => s.CustomerId == customerId).FirstOrDefault(); 
            //var customer = customers.Where(s => s.CustomerId == customerId).FirstOrDefault();

            return View("DeleteCustomer", customer);
        }
        [HttpPost]
        public ActionResult DeleteCustomer(CustomerModel customer)
        {
            var customers = _customerProvider.DeleteCustomer(new DeleteCustomerRequest() { Customer = customer });
            return RedirectToAction("Index");
        }
        public ActionResult UpDateCustomer(int? customerId)
        {
            //var customers = _customerProvider.GetCustomers(new GetCustomerRequest() {CustomerId=customerId }).Customers;
            //var customer = customers.Where(s => s.CustomerId == customerId).FirstOrDefault();
            CustomerViewModel model = new CustomerViewModel();
            model.Customer = _customerProvider.GetCustomers(new GetCustomerRequest { CustomerId = customerId }).Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
            var _orders = _customerProvider.GetCustomerOrder(new GetCustomerOrderRequest { CustomerId = customerId }).CustomerOrder;

            model.OrderModels = _orders;
            return View("UpDateCustomer", model);
        }
        [HttpPost]
        public ActionResult UpDateCustomer(CustomerModel customer)
        {
            var response = _customerProvider.UpDateCustomer(new UpDateCustomerRequest() { Customer = customer });

            return RedirectToAction("Index");
        }
        public ActionResult Details(int customerId)
        {
            var customers = _customerProvider.GetCustomers(new GetCustomerRequest() { }).Customers;
            var customerss = customers.Where(s => s.CustomerId == customerId).FirstOrDefault();
            return View("UpDateCustomer", customerss);

        }
        public ActionResult GetCustomerOrder(int? customerId)
        {
            CustomerViewModel model = new CustomerViewModel();
            model.Customer = _customerProvider.GetCustomers(new GetCustomerRequest { CustomerId = customerId }).Customers.FirstOrDefault();
            model.OrderModels = _customerProvider.GetCustomerOrder(new GetCustomerOrderRequest { CustomerId = customerId }).CustomerOrders;

            return View("GetCustomerOrder", model);
        }
        //[HttpPost]
        //public string SearchResult(string SearchKey)
        //{
        //    CustomerModel customer = new CustomerModel();
        //    customer.= Customer(SearchKey);
        //    string strTable = "";
        //    strTable = strTable + "< table>< thead>< tr>< th>ID</ th >< th >Product Name</ th >";
        //    strTable = strTable + "< th >Product Detail</ th >< th >Current Stock< / th></ tr></ thead>< tbody>";


        //    foreach (var item in customer.ProductList)
        //    {
        //        strTable = strTable + "< tr >";
        //        strTable = strTable + "< td >" + item.ID + "</ td >";
        //        strTable = strTable + "< td >" + item.ProductName + "</ td >";
        //        strTable = strTable + "< td >" + item.ProductDetail + "</ td >";
        //        strTable = strTable + "< td>" + item.CurrentStock + "</ td >";
        //        strTable = strTable + "</ tr >";
        //    }
        //    strTable = strTable + "</ tbody ></ table >";
        //    return strTable;


        public string IsDuplicateEmail(string email, string name, string address)
        {
            string resp = string.Empty;
            var customers = _customerProvider.GetCustomers(new GetCustomerRequest()).Customers;
            var customer = customers.Where(s => s.CustomerEmail == email && s.CustomerAddress == address && s.CustomerName == name).FirstOrDefault();
            //var name = customers.Where(s => s.CustomerName == customerName).FirstOrDefault();


            if (customer != null)
            {
                resp = " alredy existed";
            }
            return resp;

        }
        //[HttpGet]
        //public string IsDuplicateName(string customerName)
        //{
        //    string resp = string.Empty;
        //    var customers = _customerProvider.GetCustomers(new GetCustomerRequest()).Customers;
        //    var customer = customers.Where(s => s.CustomerName == customerName).FirstOrDefault();
        //    //var name = customers.Where(s => s.CustomerName == customerName).FirstOrDefault();


        //    if (customer != null)
        //    {
        //        resp = " alredy existed";
        //    }
        //    return resp;

        //}
        public JsonResult  IsActive_save(bool isActive,int customerId)
        {
            string resp = string.Empty;
            var customers = _customerProvider.IsActive_Save(new IsActiveRequest() { IsActive = !isActive,CustomerId=customerId});
       
            //var name = customers.Where(s => s.CustomerName == customerName).FirstOrDefault();

            return Json(customers);
           
        }
     
        }
    }
