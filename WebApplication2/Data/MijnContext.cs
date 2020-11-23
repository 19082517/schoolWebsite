using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class MijnContext : DbContext
    {
        public MijnContext(DbContextOptions options) : base(options) { }
        public DbSet<Student> students { get; set; }
    }
}
