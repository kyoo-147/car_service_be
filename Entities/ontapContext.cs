using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace test.Entities
{
    public partial class ontapContext : DbContext
    {
        public ontapContext()
        {
        }

        public ontapContext(DbContextOptions<ontapContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dangkycungcap> Dangkycungcaps { get; set; } = null!;
        public virtual DbSet<Dongxe> Dongxes { get; set; } = null!;
        public virtual DbSet<Loaidichvu> Loaidichvus { get; set; } = null!;
        public virtual DbSet<Mucphi> Mucphis { get; set; } = null!;
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=P0302; Initial Catalog=ontap; Integrated Security=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dangkycungcap>(entity =>
            {
                entity.HasKey(e => e.MaDkcc);

                entity.ToTable("DANGKYCUNGCAP");

                entity.Property(e => e.MaDkcc)
                    .HasMaxLength(7)
                    .HasColumnName("MaDKCC");

                entity.Property(e => e.DongXe).HasMaxLength(15);

                entity.Property(e => e.MaLoaiDv)
                    .HasMaxLength(6)
                    .HasColumnName("MaLoaiDV");

                entity.Property(e => e.MaMp)
                    .HasMaxLength(5)
                    .HasColumnName("MaMP");

                entity.Property(e => e.MaNhaCc)
                    .HasMaxLength(8)
                    .HasColumnName("MaNhaCC");

                entity.Property(e => e.NgayBatDauCungCap).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThucCungCap).HasColumnType("datetime");

                entity.HasOne(d => d.DongXeNavigation)
                    .WithMany(p => p.Dangkycungcaps)
                    .HasForeignKey(d => d.DongXe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_DANGKYCUNGCAP_DongXe");

                entity.HasOne(d => d.MaLoaiDvNavigation)
                    .WithMany(p => p.Dangkycungcaps)
                    .HasForeignKey(d => d.MaLoaiDv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_DANGKYCUNGCAP_MaLoaiDV");

                entity.HasOne(d => d.MaMpNavigation)
                    .WithMany(p => p.Dangkycungcaps)
                    .HasForeignKey(d => d.MaMp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_DANGKYCUNGCAP_MaMP");

                entity.HasOne(d => d.MaNhaCcNavigation)
                    .WithMany(p => p.Dangkycungcaps)
                    .HasForeignKey(d => d.MaNhaCc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_DANGKYCUNGCAP_MaNhaCC");
            });

            modelBuilder.Entity<Dongxe>(entity =>
            {
                entity.HasKey(e => e.DongXe1);

                entity.ToTable("DONGXE");

                entity.Property(e => e.DongXe1)
                    .HasMaxLength(15)
                    .HasColumnName("DongXe");

                entity.Property(e => e.HangXe).HasMaxLength(10);
            });

            modelBuilder.Entity<Loaidichvu>(entity =>
            {
                entity.HasKey(e => e.MaLoaiDv);

                entity.ToTable("LOAIDICHVU");

                entity.Property(e => e.MaLoaiDv)
                    .HasMaxLength(6)
                    .HasColumnName("MaLoaiDV");

                entity.Property(e => e.TenLoaiDv)
                    .HasMaxLength(50)
                    .HasColumnName("TenLoaiDV");
            });

            modelBuilder.Entity<Mucphi>(entity =>
            {
                entity.HasKey(e => e.MaMp);

                entity.ToTable("MUCPHI");

                entity.Property(e => e.MaMp)
                    .HasMaxLength(5)
                    .HasColumnName("MaMP");

                entity.Property(e => e.DonGia).HasMaxLength(7);

                entity.Property(e => e.MoTa).HasMaxLength(30);
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.HasKey(e => e.MaNhaCc);

                entity.ToTable("NHACUNGCAP");

                entity.Property(e => e.MaNhaCc)
                    .HasMaxLength(8)
                    .HasColumnName("MaNhaCC");

                entity.Property(e => e.DiaChi).HasMaxLength(30);

                entity.Property(e => e.MaSoThue).HasMaxLength(15);

                entity.Property(e => e.SoDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SoDT");

                entity.Property(e => e.TenNhaCc)
                    .HasMaxLength(50)
                    .HasColumnName("TenNhaCC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
