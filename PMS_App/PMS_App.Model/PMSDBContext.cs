using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_App.Model
{
    public class PMSDBContext : DbContext
    {
        public PMSDBContext(DbContextOptions<PMSDBContext> option) : base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Employee> Employee { get; set; }
   

    }
}
