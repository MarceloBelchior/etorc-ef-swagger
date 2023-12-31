﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using torc.model;

namespace torc.database
{
    public class TorcDB : DbContext
    {


        //for migrations constructor must be empty;
        //dotnet ef migrations script --output ./Migrations/MyMigrationScript.sql

        //public TorcDB() {}


        //for migrations constructor 
        public TorcDB(DbContextOptions<TorcDB> options) : base(options)
        {
        }


        // DbSet properties representing your entities
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }


        // Override OnModelCreating method if you need to configure entity relationships or other model-specific configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships, indices, etc.
            modelBuilder.Entity<Order>().Property(o => o.Cost).HasPrecision(18, 2); // Specify the desired precision and scale
            modelBuilder.Entity<Order>().Property(o => o.Id).HasColumnName("OrderId");

            modelBuilder.Entity<Order>()
               .HasOne(o => o.Product);

       //     modelBuilder.Entity<Product>()
        //     .HasMany(p => p.Orders)
       //      .WithOne(o => o.Products)
       //      .HasForeignKey(o => o.ProductId);


            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);


        }

        //For Migration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseLazyLoadingProxies();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Torc;User Id=sa;Password=YourPassword123;TrustServerCertificate=true;");
            }
        }

    }
}

