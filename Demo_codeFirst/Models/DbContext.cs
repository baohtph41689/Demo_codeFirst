using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    internal class AppliCationDbContext : DbContext
    {
        public DbSet<product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }

        // Chuỗi kết nối tới CSDL ( SQL Server)
        private const string connectionString = @"
                Data Source=localhost;
                Initial Catalog=DemoCodeFirst ;
                User ID=sa;Password=123456;TrustServerCertificate=True ";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
