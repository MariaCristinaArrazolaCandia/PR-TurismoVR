using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Turismo_API.Models;

namespace Turismo_API.Data;

public partial class BdTurismoTiquipayaContext : DbContext
{
    public BdTurismoTiquipayaContext()
    {
    }

    public BdTurismoTiquipayaContext(DbContextOptions<BdTurismoTiquipayaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Horary> Horaries { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonRegister> PersonRegisters { get; set; }

    public virtual DbSet<PhotoTouristSite> PhotoTouristSites { get; set; }

    public virtual DbSet<TouristSite> TouristSites { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.RegisterDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Horary>(entity =>
        {
            entity.Property(e => e.RegisterDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.TouristSite).WithMany(p => p.Horaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Horary_TouristSite");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.Gender)
                .IsFixedLength()
                .HasComment("M : Male\r\nF : Female");
            entity.Property(e => e.State)
                .HasDefaultValueSql("((1))")
                .HasComment("1: Enable\r\n0: Disable");
        });

        modelBuilder.Entity<PersonRegister>(entity =>
        {
            entity.Property(e => e.RegisterDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonRegisters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_Register_Person");

            entity.HasOne(d => d.UserPerson).WithMany(p => p.PersonRegisters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_Register_User");
        });

        modelBuilder.Entity<PhotoTouristSite>(entity =>
        {
            entity.Property(e => e.RegisterDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.TouristSite).WithMany(p => p.PhotoTouristSites)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhotoTouristSite_TouristSite");
        });

        modelBuilder.Entity<TouristSite>(entity =>
        {
            entity.Property(e => e.RegisterDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Category).WithMany(p => p.TouristSites).HasConstraintName("FK_TouristSite_Category");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK_User_1");

            entity.Property(e => e.PersonId).ValueGeneratedNever();
            entity.Property(e => e.Rol)
                .IsFixedLength()
                .HasComment("S: SuperAdmin\r\nA: Admin\r\nC: Customer");

            entity.HasOne(d => d.Person).WithOne(p => p.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Person");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
