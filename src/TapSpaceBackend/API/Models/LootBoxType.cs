namespace API.Models;

public class LootBoxType
{
    public int Id { get; set; }
    public string TypeName { get; set; }

    public ICollection<PlayerLootBox> PlayerLootBoxes { get; set; }
}