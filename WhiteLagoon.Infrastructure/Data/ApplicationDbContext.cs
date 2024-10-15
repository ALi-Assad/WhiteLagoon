using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        public DbSet<Amenity> Amenities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
        new Villa
        {
            Id = 1,
            Name = "Sunset Villa",
            Descreption = "A beautiful villa with a stunning sunset view.",
            Price = 250.0,
            Sqft = 1500,
            Occupancy = 4,
            ImageUrl = "https://placehold.co/600x401",
            Created_Date = DateTime.Now,
            Updated_Date = DateTime.Now
        },
        new Villa
        {
            Id = 2,
            Name = "Mountain Retreat",
            Descreption = "A cozy retreat in the mountains.",
            Price = 300.0,
            Sqft = 2000,
            Occupancy = 6,
            ImageUrl = "https://placehold.co/600x401",
            Created_Date = DateTime.Now,
            Updated_Date = DateTime.Now
        },
        new Villa
        {
            Id = 3,
            Name = "Beachfront Bungalow",
            Descreption = "A charming bungalow right on the beach.",
            Price = 400.0,
            Sqft = 1800,
            Occupancy = 5,
            ImageUrl = "https://placehold.co/600x401",
            Created_Date = DateTime.Now,
            Updated_Date = DateTime.Now
        },
        new Villa
        {
            Id = 4,
            Name = "City Lights Loft",
            Descreption = "A modern loft with a view of the city lights.",
            Price = 350.0,
            Sqft = 1200,
            Occupancy = 3,
            ImageUrl = "https://placehold.co/600x401",
            Created_Date = DateTime.Now,
            Updated_Date = DateTime.Now
        },
        new Villa
        {
            Id = 5,
            Name = "Countryside Cottage",
            Descreption = "A quaint cottage in the countryside.",
            Price = 200.0,
            Sqft = 1400,
            Occupancy = 4,
            ImageUrl = "https://placehold.co/600x401",
            Created_Date = DateTime.Now,
            Updated_Date = DateTime.Now
        },
        new Villa
        {
            Id = 6,
            Name = "Lakeview Lodge",
            Descreption = "A luxurious lodge with a view of the lake.",
            Price = 450.0,
            Sqft = 2200,
            Occupancy = 8,
            ImageUrl = "https://placehold.co/600x401",
            Created_Date = DateTime.Now,
            Updated_Date = DateTime.Now
        }
    );

            modelBuilder.Entity<VillaNumber>().HasData(
                new VillaNumber
                {
                    Villa_Number = 101,
                    VillaId = 1
                }, new VillaNumber
                {
                    Villa_Number = 102,
                    VillaId = 1
                }, new VillaNumber
                {
                    Villa_Number = 103,
                    VillaId = 1
                }, new VillaNumber
                {
                    Villa_Number = 201,
                    VillaId = 2
                }, new VillaNumber
                {
                    Villa_Number = 202,
                    VillaId = 2
                }, new VillaNumber
                {
                    Villa_Number = 203,
                    VillaId = 2
                }, new VillaNumber
                {
                    Villa_Number = 301,
                    VillaId = 3
                }, new VillaNumber
                {
                    Villa_Number = 302,
                    VillaId = 3
                }, new VillaNumber
                {
                    Villa_Number = 303,
                    VillaId = 3
                }, new VillaNumber
                {
                    Villa_Number = 401,
                    VillaId = 4
                }, new VillaNumber
                {
                    Villa_Number = 402,
                    VillaId = 4
                }, new VillaNumber
                {
                    Villa_Number = 403,
                    VillaId = 4
                }, new VillaNumber
                {
                    Villa_Number = 501,
                    VillaId = 5
                }, new VillaNumber
                {
                    Villa_Number = 502,
                    VillaId = 5
                }, new VillaNumber
                {
                    Villa_Number = 503,
                    VillaId = 5
                }, new VillaNumber
                {
                    Villa_Number = 601,
                    VillaId = 6
                }, new VillaNumber
                {
                    Villa_Number = 602,
                    VillaId = 6
                }, new VillaNumber
                {
                    Villa_Number = 603,
                    VillaId = 6
                }
                );

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity()
                {
                    Id = 1,
                    Name= "Hotel",
                    Description = "Hotel With pool",
                    VillaId = 1,                 
                },
                 new Amenity()
                 {
                    Id = 2,
                    Name= "School",
                    Description = "School with bus",
                    VillaId = 2,                 
                },
                new Amenity()
                  {
                    Id = 3,
                    Name= "Football field",
                    Description = "football field",
                    VillaId = 3,                 
                }
                );
        }
    }
}
