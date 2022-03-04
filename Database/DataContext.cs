using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace jwt.Database
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}