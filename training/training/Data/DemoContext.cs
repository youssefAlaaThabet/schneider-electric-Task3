using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using training.Models;
using training.modes;

namespace training.Data
{
    public partial  class DemoContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DemoContext() { }
        public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
         modelBuilder.Entity<Course>(entity => 
        { entity.ToTable("Courses");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(50).
            IsUnicode(false);
            entity.HasMany(e => e.StudentCourse).
            WithOne(e => e.Course).
            HasForeignKey(e => e.CourseId);
        });
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(50).
                IsUnicode(false);
                entity.HasMany(e => e.Courses).
                WithOne(e => e.Student).
                HasForeignKey(e => e.StudentId);
            });
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.ToTable("StudentsCourses");
                entity.HasKey(e => e.Id);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
