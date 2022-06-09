#nullable disable
using Microsoft.EntityFrameworkCore;
using Gruppe11.Models;

namespace Gruppe11.Data
{
    public partial class ObservasjonContext : DbContext
    {
        public ObservasjonContext()
        {
        }

        public ObservasjonContext(DbContextOptions<ObservasjonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Observasjon> Observasjon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Observasjon>(entity =>
            {
                entity.Property(e => e.Dato).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
