using blazor_mysql2.Shared;
using Microsoft.EntityFrameworkCore;

namespace blazor_mysql2.Server
{
     public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Categoria> Categories { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetalhePedido> DetalhePedido { get; set; }

        public DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalhePedido>()
                .HasKey(p => new {p.PedidoId, p.ProductId});

            modelBuilder.Entity<DetalhePedido>()
                .HasOne(pd => pd.Pedido)
                .WithMany(pr => pr.DetalhePedidos)
                .HasForeignKey(pd => pd.PedidoId);
            
            modelBuilder.Entity<DetalhePedido>()
                .HasOne(pd => pd.Produto)
                .WithMany(pr => pr.DetalhePedidos)
                .HasForeignKey(pd => pd.ProductId);                
        }
    }
}