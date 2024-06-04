using API.Data.Models;

namespace API.Models;

public class PlayerLootBox
{
    public long PlayerId { get; set; }
    public int LootBoxTypeId { get; set; }
    public DateTime StartOpeningTime { get; set; }
    public int SlotNumber { get; set; }

    public Player? Player { get; set; }
    public LootBoxType? LootBoxType { get; set; }
}