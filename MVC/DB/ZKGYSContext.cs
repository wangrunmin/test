using MVC.DB.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC.DB
{
    public class ZKGYSContext : DbContext
    {
        public ZKGYSContext() : base()
        {
        }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierTemp> SupplierTemps { get; set; }
    }
}