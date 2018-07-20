using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OSMD.Models;

namespace OSMD.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public DbSet<News> News_Table { get; set; }
        public DbSet<Person> People { get; set; }

        public DbSet<FileModel> Files { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);
            //builder.Entity<NewsViewModel>().ToTable("News");
            //base.OnModelCreating(builder);
        }
        

        public DbSet<OSMD.Models.ApplicationUser> ApplicationUser { get; set; }
    }
    
}
