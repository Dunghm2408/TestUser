using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class DataContext : DbContext
    {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {

            }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

        }
        public DbSet<User> Users { get; set; }

        }
    }
