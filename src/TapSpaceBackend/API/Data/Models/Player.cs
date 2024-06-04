using API.Models;

namespace API.Data.Models;

public class Player
{
    public long Id { get; set; }
    public string? NickName { get; set; } = null!;
    public int Rank { get; set; }
    public int LevelsCompleted { get; set; }
    public int Experience { get; set; }
    public int Crystals { get; set; }
    public int NormalBluePrint { get; set; }
    public int AdvancedBluePrint { get; set; }
    public int RareBluePrint { get; set; }
    public int LegendaryBluePrint { get; set; }
    public int Gold { get; set; }
    public int AsteroidsDestroyed { get; set; }
    public int Wins { get; set; }
    public int PlaceAtLeaderBoard { get; set; }
    public int OpenLootBoxSlots { get; set; }
    public int OpenGunSlots { get; set; }

    public ICollection<PlayerLootBox> PlayerLootBoxes { get; set; } = new List<PlayerLootBox>();
    public ICollection<PlayerGun> PlayerGuns { get; set; } = new List<PlayerGun>();
    public ICollection<PlayerAchievement> PlayerAchievements { get; set; } = new List<PlayerAchievement>();
}