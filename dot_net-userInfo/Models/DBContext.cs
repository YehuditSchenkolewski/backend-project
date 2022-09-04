using System;
using System.Collections.Generic;
using dot_net_userInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dot_net_userInfo.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Auth> Auth { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ProjectDBConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(builder =>
            {
                builder.Property(e => e.Id)
                    .ValueGeneratedNever();

                builder.Property(e => e.Name)
                    .HasMaxLength(50);

                builder.HasOne(a => a.IdUser)
                .WithMany(q => q.Project)
                .HasForeignKey(a => a.UserId);
            });

            modelBuilder.Entity<Auth>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Token)
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdUser)
                    .WithMany()
                    .HasForeignKey(d => d.Id);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever();

                entity.Property(e => e.Avatar)
                    .HasMaxLength(1000);

                entity.Property(e => e.Email)
                    .IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired();
            });

        }
    }
}