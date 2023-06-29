using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modele;

namespace SchemaFluent.ConfigModele
{
    class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(p => p.Designation).IsRequired();
            builder.Property(p => p.Designation).HasMaxLength(50);
            builder.Property(p => p.Designation).HasMaxLength(300);
            builder.Property(p => p.Promotion).HasColumnName("Promo");
        }
    }
}
