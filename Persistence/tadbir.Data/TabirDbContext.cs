using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using tadbir.Entities;

namespace tadbir.Data
{
    public class TadbirDbContext : DbContext
    {
        public TadbirDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceRow>().HasKey(e => new { e.InvoiceId, e.ProductId });
            modelBuilder.Entity<Invoice>().Property(e => e.Serial).ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
        }
    }
}
