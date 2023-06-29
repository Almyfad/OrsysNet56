using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modele;

namespace SchemaFluent.ConfigModele
{
    class CategorieConfiguration : IEntityTypeConfiguration<Categorie>
    {
        public void Configure(EntityTypeBuilder<Categorie> builder)
        {
            builder.Property(p => p.LibelleCategorie).IsRequired();
            builder.Property(p => p.LibelleCategorie).HasMaxLength(50);
        }
    }
}
