namespace API.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Player> Players { get; set; } = default!;
    public DbSet<Achievement> Achievements { get; set; } = default!;
    public DbSet<LootBoxType> LootBoxTypes { get; set; } = default!;
    public DbSet<PlayerLootBox> PlayerLootBoxes { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigurePlayerEntity(modelBuilder);
        ConfigureAchievementEntity(modelBuilder);
        ConfigureLootBoxTypeEntity(modelBuilder);
        ConfigurePlayerLootBoxEntity(modelBuilder);
    }

    private static void ConfigurePlayerEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Level)
                .IsRequired()
                .HasDefaultValue(0);

            entity.Property(x => x.Experience)
                .IsRequired()
                .HasDefaultValue(0);

            entity.Property(x => x.AsteroidsDestroyed)
                .IsRequired()
                .HasDefaultValue(0);

            entity.Property(x => x.Crystals)
                .IsRequired()
                .HasDefaultValue(0);

            entity.Property(x => x.Shields)
                .IsRequired()
                .HasDefaultValue(0);

            entity.Property(x => x.Gold)
                .IsRequired()
                .HasDefaultValue(0);

            entity.Property(x => x.OpenSlots)
                .IsRequired()
                .HasDefaultValue(0);

            entity.HasMany(p => p.PlayerLootBoxes)
                .WithOne(plb => plb.Player)
                .HasForeignKey(plb => plb.PlayerId);
        });
    }

    private static void ConfigureAchievementEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(128);
        });
    }

    private static void ConfigureLootBoxTypeEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LootBoxType>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.TypeName)
                .IsRequired()
                .HasMaxLength(128);

            entity.HasMany(lbt => lbt.PlayerLootBoxes)
                .WithOne(plb => plb.LootBoxType)
                .HasForeignKey(plb => plb.LootBoxTypeId)
                .HasConstraintName("FK_PlayerLootBox_LootBoxType");
        });
    }

    private static void ConfigurePlayerLootBoxEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerLootBox>(entity =>
        {
            entity.Property(plb => plb.SlotNumber)
                .IsRequired();

            entity.Property(plb => plb.StartOpeningTime)
                .IsRequired();

            entity.HasOne(plb => plb.Player)
                .WithMany(p => p.PlayerLootBoxes)
                .HasForeignKey(plb => plb.PlayerId);

            entity.HasOne(plb => plb.LootBoxType)
                .WithMany(lbt => lbt.PlayerLootBoxes)
                .HasForeignKey(plb => plb.LootBoxTypeId);
        });
    }
}
