using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCorePract.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCorePract.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Users>Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5RGECJ1;Database=Users;User Id=v;Password=123;TrustServerCertificate=true;");
        }
    }
}
