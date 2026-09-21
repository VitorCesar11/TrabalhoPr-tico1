using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculosAPI.Models
{
    public class LocadoraDbContext : DbContext
    {
        // 1. Construtor vazio exigido pelas ferramentas do EF Core
        public LocadoraDbContext() { }

        // 2. Construtor padrão para a API
        public LocadoraDbContext(DbContextOptions<LocadoraDbContext> options) : base(options) { }

        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }

        // 3. Método infalível para injetar a Connection String diretamente
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // A mesma string que está no appsettings.json
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LocadoraDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Garante que não é possível registar dois clientes com o mesmo CPF
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.CPF)
                .IsUnique();
        }
    }
}