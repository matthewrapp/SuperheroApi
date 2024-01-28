using System;
using System.ComponentModel.DataAnnotations;

public class SuperHero
{
   [Key]
   public required string Id { get; set; }

   [Required]
   public required string Name { get; set; }

   public string? Superpowers { get; set; }
}