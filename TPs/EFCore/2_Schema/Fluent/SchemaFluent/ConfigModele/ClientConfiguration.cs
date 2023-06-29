using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modele;

namespace SchemaFluent.ConfigModele
{
    class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(t => t.ClientGuid);
            builder.Property(t => t.ClientGuid).ValueGeneratedOnAdd();
            builder.Property(p => p.Nom).HasMaxLength(50);
            builder.Property(p => p.Prenom).HasMaxLength(50);
            builder.Property(p => p.Email).HasMaxLength(50);
            builder.Property(p => p.RowVersion).IsRowVersion();
        }
    }
}
