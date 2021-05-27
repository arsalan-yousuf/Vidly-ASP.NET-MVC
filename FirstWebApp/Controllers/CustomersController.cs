using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstWebApp.Models;
using System.Data.Entity;

namespace FirstWebApp.Controllers
{
    public class CustomersController : Controller
    {
        private MyDBContext _context;
        public CustomersController()
        {
            _context = new MyDBContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customersList = _context.Customers.Include(c => c.MembershipType).ToList();     //this Include is called eager loading
                
                
            //    new List<Customer>
            //{
            //    new Customer {Name="Arsalan"},
            //    new Customer {Name = "Nabeel"},
            //    new Customer {Name="Hammad"},
            //    new Customer {Name="Rafaqat"}
            //};
            ViewBag.customersList = customersList;
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerDetails = customer;
            return View();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            ViewBag.membershipTypes = membershipTypes;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            ViewBag.membershipTypes = _context.MembershipTypes.ToList();
            return View("New", customer);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var custInDb = _context.Customers.Single(c => c.Id == customer.Id);
                custInDb.Name = customer.Name;
                custInDb.BirthDate = customer.BirthDate;
                custInDb.MembershipTypeId = customer.MembershipTypeId;
                custInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}