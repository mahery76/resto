using Microsoft.EntityFrameworkCore;
using resto.domain.Entities;

namespace resto.infrastructure.Data;

public class ProduitContext : DbContext
{
    public DbSet<Produit> Produits { get; set; } = null!;

    public ProduitContext(DbContextOptions<ProduitContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produit>()
            .Property(p => p.Id)
            .HasDefaultValueSql("NEWID()");
    }
}


