using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }
       public DbSet<WrestlingSchool> WrestlingSchools { get; set; }
    }
}
