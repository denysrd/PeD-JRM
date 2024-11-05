using Microsoft.EntityFrameworkCore;
using PeD_JRM.Models;

namespace PeD_JRM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Defina um DbSet para cada entidade/tabela
        public DbSet<FornecedorModel> Fornecedor
        {
            get; set;
        }
        public DbSet<TipoIngrediente> TipoIngredientes
        {
            get; set;
        }
        public DbSet<TipoFormulacao> TipoFormulacoes
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Fornecedor
            modelBuilder.Entity<FornecedorModel>(entity =>
            {
                entity.ToTable("tbl_fornecedor");
                entity.HasKey(e => e.Id_Fornecedor);
                entity.Property(e => e.Id_Fornecedor).ValueGeneratedOnAdd();
                entity.Property(e => e.Documento).IsRequired().HasMaxLength(14);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Telefone).HasMaxLength(15);
            });

            // Configuração da entidade TipoIngrediente
            modelBuilder.Entity<TipoIngrediente>(entity =>
            {
                entity.ToTable("tbl_tipo_ingrediente");
                entity.HasKey(e => e.Id_Tipo_Ingrediente);
                entity.Property(e => e.Tipo_Ingrediente).IsRequired();
                entity.Property(e => e.Descricao_Tipo_Ingrediente).HasMaxLength(255);
                entity.Property(e => e.Sigla).HasMaxLength(10);
                entity.Property(e => e.Situacao).IsRequired();
            });

            // Configuração da entidade TipoFormulacao
            modelBuilder.Entity<TipoFormulacao>(entity =>
            {
                entity.ToTable("tbl_tipo_formulacao");
                entity.HasKey(e => e.Id_Tipo_Formulacao);
                entity.Property(e => e.Tipo_Formula).IsRequired();
                entity.Property(e => e.Descricao_Formula).HasMaxLength(255);
            });
        }
    }
}
