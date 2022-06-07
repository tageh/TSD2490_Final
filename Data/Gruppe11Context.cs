﻿#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gruppe11.Data
{
    public partial class Gruppe11Context: DbContext
    {
        public Gruppe11Context()
        {
        }

        public Gruppe11Context(DbContextOptions<Gruppe11Context> options)
            : base(options)
        {
        }

        public virtual DbSet<VærData> VærData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VærData>(entity =>
            {
                entity.Property(e => e.Dato).HasColumnType("datetime");

                entity.Property(e => e.Kommentar).HasMaxLength(50);

                entity.Property(e => e.Bruker).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
