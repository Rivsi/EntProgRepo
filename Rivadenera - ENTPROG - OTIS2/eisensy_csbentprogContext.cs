using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rivadenera___ENTPROG___OTIS2
{
    public partial class eisensy_csbentprogContext : DbContext
    {
        public eisensy_csbentprogContext()
        {
        }

        public eisensy_csbentprogContext(DbContextOptions<eisensy_csbentprogContext> options)
            : base(options)
        {
        }

       

        public virtual DbSet<SuppliersInv> SuppliersInvs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("SERVER=DESKTOP-SSAA20D\\SQLEXPRESS;DATABASE=eisensy_csbentprog;UID=eisensy_student;PWD=Benilde@2020;TRUSTSERVERCERTIFICATE=true");
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eisensy_csbentprog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("eisensy_student");

           
            modelBuilder.Entity<ProductsInv>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("ProductsINV");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Unit).HasMaxLength(50);
            });

         

            modelBuilder.Entity<SuppliersInv>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.ToTable("SuppliersINV");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CompanyName).HasMaxLength(100);

                entity.Property(e => e.ContactNo).HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Representative).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
