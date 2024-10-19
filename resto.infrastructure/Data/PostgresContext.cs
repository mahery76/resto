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
        modelBuilder.Entity<Produit>()
            .Property(p => p.Id)
            .ValueGeneratedNever();

        modelBuilder.Entity<Commande>()
            .HasOne(c => c.Produit)
            .WithMany(p => p.Commande)
            .HasForeignKey(c => c.ProduitId);
    }
}
