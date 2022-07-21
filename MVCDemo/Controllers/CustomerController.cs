using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace MVCDemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            CustomerBusinessLayer customerBusinessLayer = new CustomerBusinessLayer();
            List<Customer> custlist = customerBusinessLayer.Customers.ToList();
            return View(custlist);
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {

            Customer customer = new Customer();
            TryUpdateModel(customer);
            if (ModelState.IsValid)
            {
                CustomerBusinessLayer customerBusinessLayer = new CustomerBusinessLayer();
                customerBusinessLayer.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        CustomerBusinessLayer customerBusinessLayer = new CustomerBusinessLayer();
        //        customerBusinessLayer.AddCustomer(customer);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(FormCollection frmCol)
        //{
        //    //foreach (string key in frmCol.AllKeys)
        //    //{
        //    //    Response.Write("Key = " + key + "  ");
        //    //    Response.Write("Value = " + frmCol[key]);
        //    //    Response.Write("<br/>");
        //    //}
        //    //return View();
        //    Customer customer = new Customer();
        //    // Retrieve form data using form collection
        //    customer.Name = frmCol["Name"];
        //    customer.Gender = frmCol["Gender"];
        //    customer.City = frmCol["City"];
        //    customer.DateOfBirth = Convert.ToDateTime(frmCol["DateOfBirth"]);
        //    CustomerBusinessLayer customerBusinessLayer =new CustomerBusinessLayer();
        //    customerBusinessLayer.AddCustomer(customer);
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public ActionResult Create(string name, string gender, string city, DateTime dateOfBirth)
        //{
        //    Customer customer = new Customer();
        //    customer.Name = name;
        //    customer.Gender = gender;
        //    customer.City = city;
        //    customer.DateOfBirth = dateOfBirth;

        //    CustomerBusinessLayer customerBusinessLayer =
        //        new CustomerBusinessLayer();

        //    customerBusinessLayer.AddCustomer(customer);
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CustomerBusinessLayer customerBusinessLayer = new CustomerBusinessLayer();
            Customer customer = customerBusinessLayer.Customers.Single(cust => cust.ID == id);
            return View(customer);
        }

        //[HttpPost]
        ////public ActionResult Edit( [Bind(Include = "Id, Gender, City, DateOfBirth")] Customer customer)
        //public ActionResult Edit([Bind(Exclude = "Name")] Customer customer)
        //{
        //    CustomerBusinessLayer customerBusinessLayer = new CustomerBusinessLayer();
        //    customer.Name = customerBusinessLayer.Customers.First(cust => cust.ID == customer.ID).Name;
        //    if (ModelState.IsValid)
        //    {
        //        customerBusinessLayer.SaveCustomer(customer);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            CustomerBusinessLayer customerBusinessLayer = new CustomerBusinessLayer();
            Customer customer = customerBusinessLayer.Customers.First(cust => cust.ID == id);
            //UpdateModel(customer, new string[] { "ID", "Gender", "City", "DateOfBirth" } );
            //UpdateModel(customer, null, null, new string[] { "name" });
            UpdateModel<ICustomer>(customer);
            if (ModelState.IsValid)
            {
                customerBusinessLayer.SaveCustomer(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            CustomerBusinessLayer customerBusinessLayer = new CustomerBusinessLayer();
            customerBusinessLayer.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}