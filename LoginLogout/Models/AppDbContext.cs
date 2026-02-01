using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoginLogout.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TBL_USER_MASTER> TBL_USER_MASTER { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SUDHIR");

            modelBuilder.Entity<TBL_USER_MASTER>(entity =>
            {
                entity.Property(e => e.ID).HasColumnType("NUMBER(38)");

                entity.Property(e => e.AGE)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EMAIL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GENDER)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.USER_PASSWORD)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
