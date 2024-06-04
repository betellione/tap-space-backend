namespace API.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Achievement> Achievements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Id).HasName("User_pk");

            entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("Name");

            entity.Property(x => x.Level)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName("Level");

            entity.Property(x => x.Experience)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName("Experience");

            entity.Property(x => x.AmountOfDestroyedAsteroid)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName("AmountOfDestroyedAsteroid");

            entity.Property(x => x.Crystals)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName("Crystals");

            entity.Property(x => x.Gold)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName("Gold");
        });

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(x => x.Id).HasName("Achievement_pk");

            entity.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(128);
        });
    }
}
