using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SuperheroApi.Models;

public partial class SuperHeroContext : DbContext
{
   public SuperHeroContext()
   {

   }

   public SuperHeroContext(DbContextOptions<SuperHeroContext> options)
       : base(options)
   {
   }

   public DbSet<SuperHero> SuperHeroes { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   // {
   //    if (!optionsBuilder.IsConfigured)
   //    {

   //    }
   //    // optionsBuilder.UseSqlServer("");
   // }

   // protected override void OnModelCreating(ModelBuilder modelBuilder)
   // {
   //    OnModelCreatingPartial(modelBuilder);
   // }

   // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
