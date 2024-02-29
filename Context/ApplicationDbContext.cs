using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebBasicPlatFrom.Entites;
using Microsoft.EntityFrameworkCore;

namespace ApiWebBasicPlatFrom.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }


        #region 
        //DBset ở đây
            public DbSet<Student> Students { get; set; }
            public DbSet<User> Users {get; set;}
            
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // cấu hình fluent API
            modelBuilder.Entity<Student>(entity => 
            {
                entity.ToTable("Students");
                entity.HasKey(s => s.StudentId);
            });

             modelBuilder.Entity<User>(entity => 
            {
                entity.ToTable("User");
                entity.HasKey(s => s.IdUser);
            });
        }
    }
}