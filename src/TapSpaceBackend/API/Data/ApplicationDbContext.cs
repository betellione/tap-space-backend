namespace API.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Player> Players { get; set; } = default!;
    public DbSet<Achievement> Achievements { get; set; } = default!;
    public DbSet<PlayerAchievement> PlayerAchievements { get; set; } = default!;
    public DbSet<LootBoxType> LootBoxTypes { get; set; } = default!;
    public DbSet<PlayerLootBox> PlayerLootBoxes { get; set; } = default!;
    public DbSet<GunType> GunTypes { get; set; } = default!;
    public DbSet<PlayerGun> PlayerGuns { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigurePlayerEntity(modelBuilder);
        ConfigureAchievementEntity(modelBuilder);
        ConfigurePlayerAchievementEntity(modelBuilder);
        ConfigureLootBoxTypeEntity(modelBuilder);
        ConfigurePlayerLootBoxEntity(modelBuilder);
        ConfigureGunTypeEntity(modelBuilder);
        ConfigurePlayerLootBoxEntity(modelBuilder);
        ConfigurePlayerGunEntity(modelBuilder);
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

            entity.Property(x => x.OpenLootBoxSlots)
                .IsRequired()
                .HasDefaultValue(0);
            
            entity.Property(x => x.OpenGunSlots)
                .IsRequired()
                .HasDefaultValue(0);

            entity.HasMany(p => p.PlayerLootBoxes)
                .WithOne(plb => plb.Player)
                .HasForeignKey(plb => plb.PlayerId);

            entity.HasMany(p => p.PlayerAchievements)
                .WithOne(pa => pa.Player)
                .HasForeignKey(pa => pa.PlayerId);
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

    private static void ConfigurePlayerAchievementEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerAchievement>(entity =>
        {
            entity.HasKey(pa => new { pa.PlayerId, pa.AchievementId });

            entity.Property(pa => pa.Progress)
                .IsRequired()
                .HasDefaultValue(0);

            entity.HasOne(pa => pa.Player)
                .WithMany(p => p.PlayerAchievements)
                .HasForeignKey(pa => pa.PlayerId);

            entity.HasOne(pa => pa.Achievement)
                .WithMany(a => a.PlayerAchievements)
                .HasForeignKey(pa => pa.AchievementId);
        });
    }

    private static void ConfigureLootBoxTypeEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LootBoxType>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
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
            entity.HasKey(pa => new { pa.PlayerId, pa.SlotNumber });
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
    
    private static void ConfigureGunTypeEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GunType>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(128);

            entity.HasMany(gt => gt.PlayerGuns)
                .WithOne(gb => gb.GunType)
                .HasForeignKey(pg => pg.GunTypeId)
                .HasConstraintName("FK_PlayerGun_GunType");
        });
    }
    
    private static void ConfigurePlayerGunEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerGun>(entity =>
        {
            entity.HasKey(pa => new { pa.PlayerId, pa.SlotNumber });
            entity.Property(plb => plb.SlotNumber)
                .IsRequired();

            entity.Property(plb => plb.Level)
                .IsRequired();

            entity.HasOne(pg => pg.Player)
                .WithMany(p => p.PlayerGuns)
                .HasForeignKey(pg => pg.PlayerId);

            entity.HasOne(pg => pg.GunType)
                .WithMany(gt => gt.PlayerGuns)
                .HasForeignKey(pg => pg.GunTypeId);
        });
    }
}