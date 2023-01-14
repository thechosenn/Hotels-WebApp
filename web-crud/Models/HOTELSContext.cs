using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace web_crud.Models
{
    public partial class HOTELSContext : DbContext
    {
        public HOTELSContext()
        {
        }

        public HOTELSContext(DbContextOptions<HOTELSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(e => e.Idhotel)
                    .IsClustered(false);

                entity.ToTable("HOTEL");

                entity.Property(e => e.Idhotel).HasColumnName("IDHOTEL");

                entity.Property(e => e.Amenities)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("AMENITIES")
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => new { e.Idroom, e.Iduser })
                    .IsClustered(false);

                entity.ToTable("RESERVATION");

                entity.Property(e => e.Idroom)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDROOM");

                entity.Property(e => e.Iduser).HasColumnName("IDUSER");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.HasOne(d => d.IdroomNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Idroom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESERVAT_RESERVATI_ROOM");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESERVAT_RESERVATI_USER");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => new { e.Iduser, e.Idroom })
                    .IsClustered(false);

                entity.ToTable("REVIEW");

                entity.Property(e => e.Iduser)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDUSER");

                entity.Property(e => e.Idroom).HasColumnName("IDROOM");

                entity.Property(e => e.Rating)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("RATING");

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("TEXT");

                entity.HasOne(d => d.IdroomNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Idroom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REVIEW_REVIEW_ROOM");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REVIEW_REVIEW2_USER");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Idroom)
                    .IsClustered(false);

                entity.ToTable("ROOM");

                entity.Property(e => e.Idroom).HasColumnName("IDROOM");

                entity.Property(e => e.Amenities)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("AMENITIES")
                    .IsFixedLength();

                entity.Property(e => e.Capacite)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAPACITE")
                    .IsFixedLength();

                entity.Property(e => e.Idhotel).HasColumnName("IDHOTEL");

                entity.Property(e => e.Roomtype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROOMTYPE")
                    .IsFixedLength();

                entity.HasOne(d => d.IdhotelNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.Idhotel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROOM_CONTIEN_HOTEL");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .IsClustered(false);

                entity.ToTable("USER");

                entity.Property(e => e.Iduser).HasColumnName("IDUSER");

                entity.Property(e => e.Adresse)
                    .HasColumnType("text")
                    .HasColumnName("ADRESSE");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL")
                    .IsFixedLength();

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD")
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasColumnType("numeric(20, 0)")
                    .HasColumnName("PHONE");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
