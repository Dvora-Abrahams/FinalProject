using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class DB_Manager : DbContext
{
    public DB_Manager()
    {
    }

    public DB_Manager(DbContextOptions<DB_Manager> options)
        : base(options)
    {
    }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<GoodsToOrder> GoodsToOrders { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Desktop\\סמינר\\finalProj\\DAL\\data\\DB.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Goods__3214EC0764923969");

            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<GoodsToOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GoodsToO__3214EC07B9B99268");

            entity.HasOne(d => d.IdGoodsNavigation).WithMany(p => p.GoodsToOrders)
                .HasForeignKey(d => d.IdGoods)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GoodsToOrders_ToTable");

            entity.HasOne(d => d.IdOrdersNavigation).WithMany(p => p.GoodsToOrders)
                .HasForeignKey(d => d.IdOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GoodsToOrders_ToTable1");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Messages__3214EC0720158D53");

            entity.Property(e => e.Content).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.SentAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.StoreId).HasDefaultValue(1);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Messages)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_Supplier");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC0705F125EA");

            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("waiting")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.IdSuppliersNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdSuppliers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_ToTable");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sales__3214EC07771CB703");

            entity.Property(e => e.SaleDate).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdWarehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_ToWarehouse");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC0713A54606");

            entity.Property(e => e.Company)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.RepresentativeName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warehous__3214EC077EF8A977");

            entity.ToTable("Warehouse");

            entity.HasOne(d => d.IdGoodsNavigation).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.IdGoods)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_ToGoods");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
