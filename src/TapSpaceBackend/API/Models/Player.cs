namespace API.Models;

public class Player
{
    public int Id { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int Crystals { get; set; }
    public int Gold { get; set; }
    public int AsteroidsDestroyed { get; set; }
    public int Shields { get; set; }
    public int OpenLootBoxSlots { get; set; }
    public int OpenGunSlots { get; set; }

    public ICollection<PlayerLootBox> PlayerLootBoxes { get; set; } = new List<PlayerLootBox>();
    public ICollection<PlayerGun> PlayerGuns { get; set; } = new List<PlayerGun>();
    public ICollection<PlayerAchievement> PlayerAchievements { get; set; } = new List<PlayerAchievement>();
}