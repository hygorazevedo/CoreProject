using CoreProject.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.Infraestructure
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cliente>(entity => 
            {
                entity.HasKey(p => p.ClienteId);

                entity.Property(p => p.ClienteId)
                    .HasColumnName("CLIENTE_ID");

                entity.Property(p => p.Nome)
                    .HasColumnName("NOME");

                entity.Property(p => p.Cpf)
                    .HasColumnName("CPF");

                entity.Property(p => p.Telefone)
                    .HasColumnName("TELEFONE");

                entity.Property(p => p.DataCadastro)
                    .HasColumnName("DATA_CADASTRO");

                entity.ToTable("CLIENTE");
            });
        }
    }
}
