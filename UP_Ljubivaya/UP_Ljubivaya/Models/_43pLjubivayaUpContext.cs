using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UP_Ljubivaya.Models;

public partial class _43pLjubivayaUpContext : DbContext
{
    public _43pLjubivayaUpContext()
    {
    }

    public _43pLjubivayaUpContext(DbContextOptions<_43pLjubivayaUpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialsType> MaterialsTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnersProduct> PartnersProducts { get; set; }

    public virtual DbSet<PartnersType> PartnersTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsType> ProductsTypes { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=edu.pg.ngknn.local;Port=5432;Database=43P_Ljubivaya_UP;Username=43P;Password=444444");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialsType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("materials_type_pkey");

            entity.ToTable("materials_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Defect).HasColumnName("defect");
            entity.Property(e => e.MaterialType)
                .HasMaxLength(255)
                .HasColumnName("material_type");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partners_pkey");

            entity.ToTable("partners");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FioDirector)
                .HasMaxLength(255)
                .HasColumnName("fio_director");
            entity.Property(e => e.History)
                .HasMaxLength(255)
                .HasColumnName("history");
            entity.Property(e => e.Inn)
                .HasMaxLength(10)
                .HasColumnName("inn");
            entity.Property(e => e.Logo)
                .HasMaxLength(255)
                .HasColumnName("logo");
            entity.Property(e => e.PartnerType).HasColumnName("partner_type");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .HasColumnName("phone");
            entity.Property(e => e.PlaceSale)
                .HasMaxLength(255)
                .HasColumnName("place_sale");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UrAddress)
                .HasMaxLength(255)
                .HasColumnName("ur_address");

            entity.HasOne(d => d.PartnerTypeNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.PartnerType)
                .HasConstraintName("partners_partner_type_fkey");
        });

        modelBuilder.Entity<PartnersProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partners_products_pkey");

            entity.ToTable("partners_products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Partner).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("partners_products_partner_id_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("partners_products_product_id_fkey");
        });

        modelBuilder.Entity<PartnersType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partners_type_pkey");

            entity.ToTable("partners_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Article)
                .HasMaxLength(8)
                .HasColumnName("article");
            entity.Property(e => e.Heigth).HasColumnName("heigth");
            entity.Property(e => e.Length).HasColumnName("length");
            entity.Property(e => e.MinCost)
                .HasPrecision(10, 2)
                .HasColumnName("min_cost");
            entity.Property(e => e.Photo)
                .HasMaxLength(255)
                .HasColumnName("photo");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductType).HasColumnName("product_type");
            entity.Property(e => e.Width).HasColumnName("width");

            entity.HasOne(d => d.ProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductType)
                .HasConstraintName("products_product_type_fkey");
        });

        modelBuilder.Entity<ProductsType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_type_pkey");

            entity.ToTable("products_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Koeff)
                .HasPrecision(5, 4)
                .HasColumnName("koeff");
            entity.Property(e => e.ProductType)
                .HasMaxLength(255)
                .HasColumnName("product_type");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("staff_pkey");

            entity.ToTable("staff");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankDetails)
                .HasMaxLength(255)
                .HasColumnName("bank_details");
            entity.Property(e => e.DateBirth).HasColumnName("date_birth");
            entity.Property(e => e.Family)
                .HasMaxLength(255)
                .HasColumnName("family");
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .HasColumnName("fio");
            entity.Property(e => e.HealthStatus)
                .HasMaxLength(255)
                .HasColumnName("health_status");
            entity.Property(e => e.Passport)
                .HasMaxLength(11)
                .HasColumnName("passport");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
