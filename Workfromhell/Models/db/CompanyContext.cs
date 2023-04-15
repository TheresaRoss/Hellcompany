using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Workfromhell.Models.db;

public partial class CompanyContext : DbContext
{
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerOwn> CustomerOwns { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamEmployee> TeamEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=Company; Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<CustomerOwn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CustomerOwn");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany()
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerOwn_Customer");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerOwn_Product");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Joined).HasColumnType("datetime");
            entity.Property(e => e.Lastname).HasMaxLength(80);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.TeamId).HasColumnName("TeamID");

            entity.HasOne(d => d.Team).WithMany(p => p.Products)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Team");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Comment).IsUnicode(false);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Enddate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Startdate).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.Projects)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Project_Employee");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("Team");

            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<TeamEmployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TeamEmployee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.TeamId).HasColumnName("TeamID");

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamEmployee_Employee");

            entity.HasOne(d => d.Team).WithMany()
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamEmployee_Team");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
