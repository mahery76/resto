using Microsoft.EntityFrameworkCore;
using resto.domain.Entities;

namespace resto.infrastructure.Data;

public class PostgresContext : DbContext
{
    public DbSet<Produit> Produits { get; set; } = null!;
    public DbSet<Commande> Commandes {get; set; } = null!;
    public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Commande>()
            .HasOne(c => c.Produit)
            .WithMany()
            .HasForeignKey(c => c.ProduitId);
    }
}
