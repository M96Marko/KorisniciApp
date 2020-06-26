using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dal
{
    public partial class KorisniciContext : DbContext
    {
        public KorisniciContext()
        {
        }

        public KorisniciContext(DbContextOptions<KorisniciContext> options)
            : base(options)
        {
        }

        public virtual DbSet<tblKorisnik> tblKorisnik { get; set; }
        public virtual DbSet<tblMjesto> tblMjesto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=DESKTOP-3D3S2HD\\LOCAL;initial catalog=Korisnici;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblKorisnik>(entity =>
            {
                entity.ToTable("tblKorisnik");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.BrojMobitela).HasMaxLength(20);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Spol)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Mjesto)
                    .WithMany()
                    .HasForeignKey(d => d.MjestoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblKorisnik_tblMjesto");
            });

            modelBuilder.Entity<tblMjesto>(entity =>
            {
                entity.ToTable("tblMjesto");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
