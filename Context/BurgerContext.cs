using System;
using backendproject.Models;
using Microsoft.EntityFrameworkCore;

namespace backendproject.Context
{
    public class BurgerContext : DbContext
    {
        public DbSet<Product> Products { get; set; } //<—— Tabell Products
        public DbSet<BongDetails> BongsDetails { get; set; } //<—— Tabell BongDetails
        public DbSet<Ingridient> Ingridients { get; set; } //<—— Tabell Ingridient
        public DbSet<Bong> Bongs { get; set; } //<—— Tabell Bongs
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=burger.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Burger = "Burger",
                Price = 50,

            });
            
            modelBuilder.Entity<Ingridient>().HasData(new Ingridient
            {
                Id = 1,
                IngridientName = "Salad",
                Price = 1
            },
            new Ingridient
            {
                Id = 2,
                IngridientName = "Cheese",
                Price = 2
            },
            new Ingridient
            {
                Id = 3,
                IngridientName = "Bacon",
                Price = 3
            },
            new Ingridient
            {
                Id = 4,
                IngridientName = "Meat",
                Price = 10
            });
            modelBuilder.Entity<BongDetails>().HasData(new BongDetails
            {
                Id = 1,
                ProductId = 1,
                IngridientId = 1,
                
            },
            new BongDetails
               {
                Id = 2,
                ProductId = 1,
                IngridientId = 1,
                
            });

            modelBuilder.Entity<Bong>().HasData(new Bong 
            {
                    Id = 1,
                    created = DateTime.Now
            });
        }
    }
}
        

           




