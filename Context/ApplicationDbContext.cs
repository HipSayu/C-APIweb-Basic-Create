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
            public DbSet<Classroom> Classrooms {get; set;}
            public DbSet<StudentClassroom> studentClassrooms {get; set;}

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

              modelBuilder.Entity<Classroom>(entity => 
            {
                entity.ToTable("Classroom");
                entity.HasKey(s => s.ClassroomId);
            });
            
            modelBuilder.Entity<StudentClassroom>(entity => 
            {
                entity.ToTable("StudentClassroom");
                entity.HasKey(s => s.IdStudentClassroom);

                entity.HasOne(e => e.student)
                .WithMany(e => e.studentClassrooms) //navigation
                .HasForeignKey(e => e.StudentId)
                .HasConstraintName("FK_StudentClassroom_Student");

                entity.HasOne(e => e.classroom)
                .WithMany(e => e.studentClassrooms)
                .HasForeignKey(e => e.ClassroomId)
                .HasConstraintName("FK_StudentClassroom_Classroom");
            });
        }
    }
}