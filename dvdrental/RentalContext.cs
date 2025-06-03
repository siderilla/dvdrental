using dvdrental.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental
{
    internal class RentalContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=rental;Username=postgres;Password=superpippo;");
            optionsBuilder.UseNpgsql(AppConfig.GetConnectionString()); //per usare il connection string dal file appConfig.json
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Film>()
            //    .HasKey(f => f.FilmId); //primary key configuration
            //modelBuilder.Entity<Film>()
            //    .Property(f => f.FilmId)
            //    .UseIdentityColumn();
            //modelBuilder.Entity<Film>()
            //    .Property(f => f.Title)
            //    .HasMaxLength(255);
            //modelBuilder.Entity<Film>()
            //    .Property(f => f.Description)
            //    .HasMaxLength(1000);

            //non è possibile settare serial nell'entity framework, ma si può usare UseIdentityColumn per postgres
            //serial è l'id autoincrementale in postgres, equivalente a identity in sql server

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(f => f.FilmId);
                entity.Property(f => f.FilmId).UseIdentityColumn();
                entity.Property(f => f.Title).HasMaxLength(255);
                //.HasColumnType("varchar(255)");
                entity.Property(f => f.Description).HasMaxLength(1000);
                entity.Property(f => f.FullText).HasMaxLength(255);
                entity.Property(f => f.Rating).HasMaxLength(10);
                entity.Property(f => f.SpecialFeatures).HasMaxLength(255);
                entity.HasOne(f => f.Language)
                      .WithMany(l => l.Films)
                      .HasForeignKey(f => f.LanguageId);
            });

            modelBuilder.Entity<Category>(category =>
            {
                category.HasKey(c => c.CategoryId);
                category.Property(c => c.CategoryId).UseIdentityColumn();
                category.Property(c => c.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Categories)
                .WithMany(l => l.Films)
                .UsingEntity(j => j.ToTable("FilmLanguages"));

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(l => l.LanguageId);
                entity.Property(l => l.LanguageId).UseIdentityColumn();
                entity.Property(l => l.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Actor>(actor => {
                actor.HasKey(a => a.ActorId);
                actor.Property(a => a.ActorId).UseIdentityColumn();
                actor.Property(a => a.FirstName).HasMaxLength(45);
                actor.Property(a => a.LastName).HasMaxLength(45);
            });

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Actors)
                .WithMany(a => a.Films)
                .UsingEntity(j => j.ToTable("FilmActors"));

            modelBuilder.Entity<Inventory>(inventory => {
                inventory.HasKey(i => i.InventoryId);
                inventory.Property(i => i.InventoryId).UseIdentityColumn();
                inventory.HasOne(i => i.Film)
                         .WithMany(f => f.Inventories)
                         .HasForeignKey(i => i.FilmId);
            });

            modelBuilder.Entity<Rental>(rental => {
                rental.HasKey(r => r.RentalId);
                rental.Property(r => r.RentalId).UseIdentityColumn();
                rental.HasOne(r => r.Inventory)
                      .WithMany(i => i.Rentals)
                      .HasForeignKey(r => r.InventoryId);
            });
        }

    }
}
