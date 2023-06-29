using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CUD.Modele;

namespace CUD.Dal
{
    public partial class VoyagesDbContext : DbContext
    {
        public VoyagesDbContext()
        {
        }

        public VoyagesDbContext(DbContextOptions<VoyagesDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Categorie> Categories { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Croisiere> Croisieres { get; set; } = null!;
        public virtual DbSet<ModesReservation> ModesReservations { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<VEmailsClient> VEmailsClients { get; set; } = null!;
        public virtual DbSet<VVoyagesAvecCategory> VVoyagesAvecCategories { get; set; } = null!;
        public virtual DbSet<Voyage> Voyages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configBuilder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                var config = configBuilder.Build();
                string cs = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(cs);
                optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("French_CI_AS");

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.CategorieId);

                entity.Property(e => e.LibelleCategorie).HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Adresse).HasMaxLength(60);

                entity.Property(e => e.Civilite).HasMaxLength(5);

                entity.Property(e => e.CodePostal).HasMaxLength(5);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Nom).HasMaxLength(30);

                entity.Property(e => e.Prenom).HasMaxLength(30);

                entity.Property(e => e.Telephone).HasMaxLength(15);

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Ville).HasMaxLength(50);
            });

            modelBuilder.Entity<Croisiere>(entity =>
            {
                entity.HasKey(e => e.CodeVoyage)
                    .HasName("PK_Croisieres_");

                entity.Property(e => e.CodeVoyage).HasMaxLength(5);

                entity.Property(e => e.PrixJour).HasColumnType("money");

                entity.HasOne(d => d.Voyage)
                    .WithOne(p => p.Croisiere)
                    .HasForeignKey<Croisiere>(d => d.CodeVoyage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Croisieres_Voyages");
            });

            modelBuilder.Entity<ModesReservation>(entity =>
            {
                entity.HasKey(e => e.ModeReservationId);

                entity.Property(e => e.LibelleModeReservation).HasMaxLength(50);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.CodeVoyage).HasMaxLength(5);

                entity.Property(e => e.DateReservation).HasColumnType("datetime");

                entity.Property(e => e.PrixUnitaire).HasColumnType("money");

                entity.Property(e => e.Qte).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Clients");

                entity.HasOne(d => d.CodeVoyageNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CodeVoyage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Voyages");

                entity.HasOne(d => d.ModeReservationNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ModeReservation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_ModesReservations");
            });

            modelBuilder.Entity<VEmailsClient>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vEmailsClients");

                entity.Property(e => e.Civilite).HasMaxLength(5);

                entity.Property(e => e.ClientId).ValueGeneratedOnAdd();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Nom).HasMaxLength(30);

                entity.Property(e => e.Prenom).HasMaxLength(30);
            });


            modelBuilder.Entity<VVoyagesAvecCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vVoyagesAvecCategories");

                entity.Property(e => e.CodeVoyage).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Destination).HasMaxLength(50);

                entity.Property(e => e.LibelleCategorie).HasMaxLength(50);

                entity.Property(e => e.Prix).HasColumnType("money");
            });

            modelBuilder.Entity<Voyage>(entity =>
            {
                entity.HasKey(e => e.CodeVoyage);

                entity.Property(e => e.CodeVoyage)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Destination).HasMaxLength(50);

                entity.Property(e => e.Prix).HasColumnType("money");

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Voyages)
                    .HasForeignKey(d => d.CategorieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Voyages_Categories");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
