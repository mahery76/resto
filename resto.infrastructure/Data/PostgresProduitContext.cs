using Microsoft.EntityFrameworkCore;
using resto.domain.Entities;

namespace resto.infrastructure.Data;

public class PostgresProduitContext : DbContext
{
    public DbSet<Produit> Produits { get; set; } = null!;
    public PostgresProduitContext(DbContextOptions<PostgresProduitContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produit>()
            .Property(p => p.Id)
            .ValueGeneratedNever();
    }
}
