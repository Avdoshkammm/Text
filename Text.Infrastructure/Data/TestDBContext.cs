using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text.Domain.Entities;

namespace Text.Infrastructure.Data
{
    public class TestDBContext : DbContext
    {
        public TestDBContext(DbContextOptions<TestDBContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
