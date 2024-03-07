using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBasic.Entites;
using ApiWebBasicPlatFrom.Entites;
using Microsoft.EntityFrameworkCore;

namespace ApiWebBasicPlatFrom.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        #region
        //DBset ở đây
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<StudentClassroom> studentClassrooms { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<StudentSubject> StudentSubjects { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // cấu hình fluent API
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(s => s.StudentId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(p => p.Id);
                entity.HasIndex(p => p.NameProduct).IsUnique();
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

                entity
                    .HasOne(e => e.student)
                    .WithMany(e => e.studentClassrooms) //navigation
                    .HasForeignKey(e => e.StudentId)
                    .HasConstraintName("FK_StudentClassroom_Student");

                entity
                    .HasOne(e => e.classroom)
                    .WithMany(e => e.studentClassrooms)
                    .HasForeignKey(e => e.ClassroomId)
                    .HasConstraintName("FK_StudentClassroom_Classroom");
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(e => e.CategoryId);
                entity
                    .HasMany(e => e.Products)
                    .WithOne(e => e.Category)
                    .HasForeignKey(e => e.IdCategory);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.HasKey(e => e.OrdersId);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");
                entity.HasKey(e => e.OrderDetailId);

                entity
                    .HasOne(e => e.Product)
                    .WithMany(e => e.OrderDetails)
                    .HasForeignKey(e => e.ProductId)
                    .HasConstraintName("FK_OrderDetail_Product");

                entity
                    .HasOne(e => e.Order)
                    .WithMany(e => e.OrderDetails)
                    .HasForeignKey(e => e.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");
                entity.HasKey(s => s.Id);
            });

            modelBuilder.Entity<StudentSubject>(entity =>
            {
                entity.ToTable("StudentSubject");
                entity.HasKey(s => s.Id);
                entity
                    .HasOne(s => s.Student)
                    .WithMany(s => s.studentSubjects)
                    .HasForeignKey(s => s.StudentId);

                entity
                    .HasOne(s => s.Student)
                    .WithMany(s => s.studentSubjects)
                    .HasForeignKey(s => s.StudentId);
            });
        }
    }
}
