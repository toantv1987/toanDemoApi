using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ToantvOrderManageNetCore.Data.Entities;

namespace ToantvOrderManageNetCore.Data
{
    public class OrdersManagerDbContext : DbContext
    { 
        public OrdersManagerDbContext(DbContextOptions<OrdersManagerDbContext> options) : base(options) { }
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CompanyOrder> CompanyOrders { get; set; }

 

    }
}
