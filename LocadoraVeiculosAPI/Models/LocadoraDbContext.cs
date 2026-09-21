using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculosAPI.Models
{
    public class LocadoraDbContext : DbContext
    {
        
        public LocadoraDbContext() { }

       
        public LocadoraDbContext(DbContextOptions<LocadoraDbContext> options) : base(options) { }

        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LocadoraDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.CPF)
                .IsUnique();
        }
    }
}