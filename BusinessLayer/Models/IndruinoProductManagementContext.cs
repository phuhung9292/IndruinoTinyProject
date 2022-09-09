using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BusinessLayer
{
    public partial class IndruinoProductManagementContext : DbContext
    {
        public IndruinoProductManagementContext()
        {
        }

        public IndruinoProductManagementContext(DbContextOptions<IndruinoProductManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblModel> TblModels { get; set; }
        public virtual DbSet<TblPhongBan> TblPhongBans { get; set; }
        public virtual DbSet<TblRole> TblRoles { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=12345;Database=IndruinoProductManagement");
                //optionsBuilder.UseSqlServer("Server=192.168.1.13;Uid=sa123;Pwd=sa123;Database=IndruinoProductManagement");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.ToTable("tbl_Category");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdModelNavigation)
                    .WithMany(p => p.TblCategories)
                    .HasForeignKey(d => d.IdModel)
                    .HasConstraintName("FK__tbl_Categ__IdMod__2D27B809");

                entity.HasOne(d => d.IdPhongBanNavigation)
                    .WithMany(p => p.TblCategories)
                    .HasForeignKey(d => d.IdPhongBan)
                    .HasConstraintName("FK__tbl_Categ__IdPho__2E1BDC42");

                entity.HasOne(d => d.IdUserResponsibilityNavigation)
                    .WithMany(p => p.TblCategories)
                    .HasForeignKey(d => d.IdUserResponsibility)
                    .HasConstraintName("FK__tbl_Categ__IdUse__2F10007B");
            });

            modelBuilder.Entity<TblModel>(entity =>
            {
                entity.ToTable("tbl_Model");

                entity.Property(e => e.TypeModel)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPhongBan>(entity =>
            {
                entity.ToTable("tbl_PhongBan");

                entity.Property(e => e.TypePhongBan)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.ToTable("tbl_Role");

                entity.Property(e => e.TypeRole).HasMaxLength(30);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tbl_User");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__tbl_User__IdRole__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
