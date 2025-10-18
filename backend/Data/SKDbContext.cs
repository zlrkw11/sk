using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class SKDbContext : DbContext
    {
        public SKDbContext(DbContextOptions<SKDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
