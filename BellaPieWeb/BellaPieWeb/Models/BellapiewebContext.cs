using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BellaPieWeb.Models;

namespace BellaPieWeb.Models;

public partial class BellapiewebContext : DbContext
{
    public BellapiewebContext()
    {
    }

    public BellapiewebContext(DbContextOptions<BellapiewebContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

            //var builder = WebApplication.CreateBuilder();
            //var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUriAspNet"));
            //optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings: DefaultConnection"));
        }
       

    }
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    // => optionsBuilder.UseSqlServer("server=localhost; database=bellapieweb; integrated security=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<BellaPieWeb.Models.Client> Client { get; set; } = default!;

    public DbSet<BellaPieWeb.Models.Order> Order { get; set; } = default!;

    public DbSet<BellaPieWeb.Models.OrderProduct> OrderProduct { get; set; } = default!;

    public DbSet<BellaPieWeb.Models.Product> Product { get; set; } = default!;

    public DbSet<BellaPieWeb.Models.Sell> Sell { get; set; } = default!;

    public DbSet<BellaPieWeb.Models.SellProduct> SellProduct { get; set; } = default!;

    public DbSet<BellaPieWeb.Models.Stock> Stock { get; set; } = default!;

    public DbSet<BellaPieWeb.Models.Supplier> Supplier { get; set; } = default!;

    public DbSet<BellaPieWeb.Models.SupplierProduct> SupplierProduct { get; set; } = default!;

    public DbSet<BellaPieWeb.Models.Trend> Trend { get; set; } = default!;

    public DbSet<BellaPieWeb.Models.User> User { get; set; } = default!;
}
