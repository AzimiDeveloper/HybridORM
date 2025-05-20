using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hama.Core.Models;

public partial class HamaFinancialMiddlewareContext : DbContext
{
    public HamaFinancialMiddlewareContext()
    {
    }

    public HamaFinancialMiddlewareContext(DbContextOptions<HamaFinancialMiddlewareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DocumentPattern> DocumentPatterns { get; set; }

    public virtual DbSet<DocumentPatternCategory> DocumentPatternCategories { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPermission> UserPermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocumentPattern>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC07E91008D6");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Category).WithMany(p => p.DocumentPatterns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DocumentP__Categ__44FF419A");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.DocumentPatterns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DocumentP__Creat__440B1D61");
        });

        modelBuilder.Entity<DocumentPatternCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC07DB6D1C55");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC07AE29E1F8");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasConstraintName("FK_Permissions_Permissions");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07D3E70A4A");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolePerm__6400A1A8B0EBB128");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions).HasConstraintName("FK__RolePermi__Permi__5070F446");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions).HasConstraintName("FK__RolePermi__RoleI__4F7CD00D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07B0A3DFF8");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<UserPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserPerm__F972A3FEAC80BC9E");

            entity.HasOne(d => d.Permission).WithMany(p => p.UserPermissions).HasConstraintName("FK__UserPermi__Permi__5441852A");

            entity.HasOne(d => d.User).WithMany(p => p.UserPermissions).HasConstraintName("FK__UserPermi__UserI__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
