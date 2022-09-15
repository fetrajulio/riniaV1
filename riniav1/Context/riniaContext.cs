using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace riniav1
{
    public partial class riniaContext : DbContext
    {
        public riniaContext()
        {
        }

        public riniaContext(DbContextOptions<riniaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Achat> Achats { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Taille> Tailles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;database=rinia", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Achat>(entity =>
            {
                entity.HasKey(e => e.IdAchat)
                    .HasName("PRIMARY");

                entity.ToTable("achat");

                entity.Property(e => e.IdAchat).HasColumnType("int(11)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IdArticle).HasColumnType("int(11)");

                entity.Property(e => e.Nbr).HasColumnType("int(11)");

                entity.Property(e => e.PrixTotal).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.IdArt)
                    .HasName("PRIMARY");

                entity.ToTable("article");

                entity.Property(e => e.IdArt).HasColumnType("int(11)");

                entity.Property(e => e.IdTaille).HasColumnType("int(11)");

                entity.Property(e => e.LibelArt)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PrixUnitaire).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Taille>(entity =>
            {
                entity.HasKey(e => e.IdTaille)
                    .HasName("PRIMARY");

                entity.ToTable("taille");

                entity.Property(e => e.IdTaille).HasColumnType("int(11)");

                entity.Property(e => e.LibelleTaille)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("libelleTaille");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
