using BankPayments.Models;
using Microsoft.EntityFrameworkCore;

namespace BankPayments.Infrastructure;

public partial class BankPaymentsManagerDBContext : DbContext
{
    public BankPaymentsManagerDBContext()
    {
    }

    public BankPaymentsManagerDBContext(DbContextOptions<BankPaymentsManagerDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banco> Banco { get; set; }

    public virtual DbSet<Boleto> Boleto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Banco__3214EC072E12CB6B");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Boleto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Boleto__3214EC0725FEEE2A");

            entity.Property(e => e.Id).ValueGeneratedNever();

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}