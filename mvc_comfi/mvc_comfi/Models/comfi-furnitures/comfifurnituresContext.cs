using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace mvc_comfi.Models.comfi
{
    public partial class comfifurnituresContext : DbContext
    {
        public comfifurnituresContext()
        {
        }

        public comfifurnituresContext(DbContextOptions<comfifurnituresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Decor> Decors { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Furniture> Furnitures { get; set; }
        public virtual DbSet<Wfh> Wfhs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("host=localhost;database=comfi-furnitures;user id=postgres;password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Decor>(entity =>
            {
                entity.HasKey(e => e.Prodid)
                    .HasName("decor_pkey");

                entity.ToTable("decor");

                entity.Property(e => e.Prodid)
                    .ValueGeneratedNever()
                    .HasColumnName("prodid");

                entity.Property(e => e.Prodimg)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("prodimg");

                entity.Property(e => e.Prodprice).HasColumnName("prodprice");

                entity.Property(e => e.Prodquantity).HasColumnName("prodquantity");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("last_name");

                entity.Property(e => e.Suggestions)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("suggestions");
            });

            modelBuilder.Entity<Furniture>(entity =>
            {
                entity.HasKey(e => e.Prodid)
                    .HasName("furnitures_pkey");

                entity.ToTable("furnitures");

                entity.Property(e => e.Prodid)
                    .ValueGeneratedNever()
                    .HasColumnName("prodid");

                entity.Property(e => e.Prodimg)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("prodimg");

                entity.Property(e => e.Prodprice).HasColumnName("prodprice");

                entity.Property(e => e.Prodquantity).HasColumnName("prodquantity");
            });

            modelBuilder.Entity<Wfh>(entity =>
            {
                entity.HasKey(e => e.Prodid)
                    .HasName("wfh_pkey");

                entity.ToTable("wfh");

                entity.Property(e => e.Prodid)
                    .ValueGeneratedNever()
                    .HasColumnName("prodid");

                entity.Property(e => e.Prodimg)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("prodimg");

                entity.Property(e => e.Prodprice).HasColumnName("prodprice");

                entity.Property(e => e.Prodquantity).HasColumnName("prodquantity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
