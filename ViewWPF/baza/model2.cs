using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ViewWPF.baza
{
    public partial class model2 : DbContext
    {
        public model2()
            : base("name=model2")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Lekarze> Lekarzes { get; set; }
        public virtual DbSet<Pacjenci> Pacjencis { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Uzytkownicy> Uzytkownicies { get; set; }
        public virtual DbSet<Wizyty> Wizyties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uzytkownicy>()
                .HasMany(e => e.Lekarzes)
                .WithRequired(e => e.Uzytkownicy)
                .HasForeignKey(e => e.USERID);

            modelBuilder.Entity<Uzytkownicy>()
                .HasMany(e => e.Pacjencis)
                .WithRequired(e => e.Uzytkownicy)
                .HasForeignKey(e => e.USERID);

            modelBuilder.Entity<Uzytkownicy>()
                .HasMany(e => e.Wizyties)
                .WithRequired(e => e.Uzytkownicy)
                .HasForeignKey(e => e.USERID)
                .WillCascadeOnDelete(false);
        }
    }
}
