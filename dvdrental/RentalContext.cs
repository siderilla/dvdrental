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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Payment> Payments { get; set; }

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
                entity.Property(f => f.Title).HasMaxLength(255); //.HasColumnType("varchar(255)");
                entity.Property(f => f.Description).HasMaxLength(1000);
                entity.Property(f => f.FullText).HasMaxLength(255);
                entity.Property(f => f.Rating).HasMaxLength(10);
                entity.Property(f => f.SpecialFeatures).HasMaxLength(255);
                entity.HasOne(f => f.Language)
                      .WithMany(l => l.Films)
                      .HasForeignKey(f => f.LanguageId);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(l => l.LanguageId);
                entity.Property(l => l.LanguageId).UseIdentityColumn();
                entity.Property(l => l.Name).HasMaxLength(20);
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
                .UsingEntity(j => j.ToTable("FilmLanguages")
            );

            modelBuilder.Entity<Actor>(actor =>
            {
                actor.HasKey(a => a.ActorId);
                actor.Property(a => a.ActorId).UseIdentityColumn();
                actor.Property(a => a.FirstName).HasMaxLength(45);
                actor.Property(a => a.LastName).HasMaxLength(45);
            });

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Actors)
                .WithMany(a => a.Films)
                .UsingEntity(j => j.ToTable("FilmActors")
            );

            modelBuilder.Entity<Inventory>(inventory =>
            {
                inventory.HasKey(i => i.InventoryId);
                inventory.Property(i => i.InventoryId).UseIdentityColumn();
                inventory.HasOne(i => i.Film)
                         .WithMany(f => f.Inventories)
                         .HasForeignKey(i => i.FilmId);
                inventory.HasOne(i => i.Store)
                         .WithMany()
                         .HasForeignKey(i => i.StoreId);
            });

            modelBuilder.Entity<Rental>(rental =>
            {
                rental.HasKey(r => r.RentalId);
                rental.Property(r => r.RentalId).UseIdentityColumn();
                rental.HasOne(r => r.Inventory)
                      .WithMany(i => i.Rentals)
                      .HasForeignKey(r => r.InventoryId);
                rental.HasOne(r => r.Customer)
                        .WithMany(c => c.Rentals)
                        .HasForeignKey(r => r.CustomerId);
                rental.HasOne(r => r.Staff)
                        .WithMany(s => s.Rentals)
                        .HasForeignKey(r => r.StaffId);
        
            });

            modelBuilder.Entity<Customer>(customer =>
            {
                customer.HasKey(c => c.CustomerId);
                customer.Property(c => c.CustomerId).UseIdentityColumn();
                customer.Property(c => c.FirstName).HasMaxLength(50);
                customer.Property(c => c.LastName).HasMaxLength(50);
                customer.Property(c => c.Email).HasMaxLength(50);
                customer.Property(c => c.AddressId).UseIdentityColumn();
                customer.Property(customer => customer.Active)
                        .HasDefaultValue(true);
                customer.HasOne(c => c.Store)
                        .WithMany(s => s.Customers)
                        .HasForeignKey(c => c.StoreId);
            });

            modelBuilder.Entity<Store>(store =>
            {
                store.HasKey(s => s.StoreId);
                store.Property(s => s.StoreId).UseIdentityColumn();
                store.HasOne<Address>()
                      .WithMany()
                      .HasForeignKey(s => s.AddressId);
                store.HasMany(s => s.Customers)
                      .WithOne(c => c.Store)
                      .HasForeignKey(c => c.StoreId);
                store.HasOne(s => s.Manager)
                      .WithMany()
                      .HasForeignKey(s => s.ManagerStaffId);
            });

            modelBuilder.Entity<Address>(address =>
            {
                address.HasKey(a => a.AddressId);
                address.Property(a => a.AddressId).UseIdentityColumn();
                address.Property(a => a.AddressLine1).HasMaxLength(255);
                address.Property(a => a.AddressLine2).HasMaxLength(255);
                address.Property(a => a.District).HasMaxLength(255);
                address.Property(a => a.PostalCode).HasMaxLength(255);
                address.Property(a => a.Phone).HasMaxLength(20);
                address.HasOne(a => a.City)
                       .WithMany(c => c.Addresses)
                       .HasForeignKey(a => a.CityId);
                address.HasMany(a => a.Customers)
                       .WithOne(c => c.Address)
                       .HasForeignKey(c => c.AddressId);
                address.HasMany(a => a.Staffs)
                       .WithOne(s => s.Address)
                       .HasForeignKey(s => s.AddressId);
            });

            modelBuilder.Entity<City>(city =>
            {
                city.HasKey(c => c.CityId);
                city.Property(c => c.CityId).UseIdentityColumn();
                city.Property(c => c.CityName).HasMaxLength(50);
                city.HasOne(c => c.Country)
                    .WithMany(co => co.Cities)
                    .HasForeignKey(c => c.CountryId);
            });

            modelBuilder.Entity<Country>(country => {
                country.HasKey(c => c.CountryId);
                country.Property(c => c.CountryId).UseIdentityColumn();
                country.Property(c => c.CountryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Staff>(staff =>
            {
                staff.HasKey(s => s.StaffId);
                staff.Property(s => s.StaffId).UseIdentityColumn();
                staff.Property(s => s.FirstName).HasMaxLength(50);
                staff.Property(s => s.LastName).HasMaxLength(50);
                staff.Property(s => s.Email).HasMaxLength(50);
                staff.Property(s => s.Username).HasMaxLength(16);
                staff.Property(s => s.Password).HasMaxLength(40);
                staff.Property(s => s.Picture).HasMaxLength(255);
                staff.Property(s => s.Active)
                      .HasDefaultValue(true);
                staff.HasOne(s => s.Store)
                        .WithMany(st => st.Staffs)
                        .HasForeignKey(s => s.StoreId);
            });

            modelBuilder.Entity<Payment>(payment =>
            {
                payment.HasKey(p => p.PaymentId);
                payment.Property(p => p.PaymentId).UseIdentityColumn();
                payment.HasOne(p => p.Customer)
                        .WithMany(c => c.Payments)
                        .HasForeignKey(p => p.CustomerId);
                payment.HasOne(p => p.Staff)
                        .WithMany(s => s.Payments)
                        .HasForeignKey(p => p.StaffId);
                payment.HasOne(p => p.Rental)
                        .WithMany(r => r.Payments)
                        .HasForeignKey(p => p.RentalId);
            });

        }

    }
}
