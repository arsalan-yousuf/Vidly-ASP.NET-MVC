using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FirstWebApp.Models;

namespace FirstWebApp.Models
{
    public class MyDBContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public MyDBContext()
        {

        }
    }
}