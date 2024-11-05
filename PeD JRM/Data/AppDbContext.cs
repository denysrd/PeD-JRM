using Microsoft.EntityFrameworkCore;
using PeD_JRM.Models; // Certifique-se de que está usando o namespace correto para as entidades

namespace PeD_JRM.Data
{
    public class AppDbContext : DbContext
    {
        // Construtor que permite passar as opções de configuração do DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Defina um DbSet para cada entidade/tabela (exemplo para Fornecedor)
        public DbSet<Fornecedor> Fornecedores
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações de mapeamento e restrições para a entidade Fornecedor
            modelBuilder.Entity<Fornecedor>().HasKey(f => f.Id);
            modelBuilder.Entity<Fornecedor>().Property(f => f.Cnpj).IsRequired().HasMaxLength(14);
            modelBuilder.Entity<Fornecedor>().Property(f => f.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
