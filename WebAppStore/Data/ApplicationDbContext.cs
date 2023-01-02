using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebAppStore.Data.Models;

namespace WebAppStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public  DbSet<ProductsInfo> ProductsInfo { get; set; }
        public  DbSet<Users> Users { get; set; }

        [NotMapped]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductsInfo>(entity =>
            {
                entity.Property(e => e.BuyPrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.ImageMimeType)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ImagePath).HasMaxLength(4000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SellPrice).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(15);
            });

        
    }

     //   partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

