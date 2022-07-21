using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class ModelsContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<BusinessLayer.Customer> Customers { get; set; }
    }
}