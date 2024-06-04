namespace API.Models;

public class LootBoxType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<PlayerLootBox> PlayerLootBoxes { get; set; } = new List<PlayerLootBox>();
}