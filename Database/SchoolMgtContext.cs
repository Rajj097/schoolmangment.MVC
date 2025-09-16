using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace schoolmangment.MVC.Database;

public partial class SchoolMgtContext : DbContext
{
    public SchoolMgtContext()
    {
    }

    public SchoolMgtContext(DbContextOptions<SchoolMgtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Lecture> Lectures { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost, 1400;Database=SchoolMGT;Trusted_Connection=false;MultipleActiveResultsets=true;Encrypt=false;user id=sa;password=Str0ngPa$$w0rd");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__course__3213E83FA17A855E");

            entity.ToTable("course");

            entity.HasIndex(e => e.Code, "UQ__course__357D4CF9A2F03DC7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Credits).HasColumnName("credits");
            entity.Property(e => e.Name)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lecture__3213E83FF55C9B2A");

            entity.ToTable("lecture");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lname");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student__3213E83FE7E756A2");

            entity.ToTable("student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
