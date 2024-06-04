using API.API.Responses.Common;
using API.Data.Models;

namespace API.API.Responses.Dto;

public class PlayerProfileDto(Player player)
{
    public long Id { get; init; } = player.Id;
    public string? Nickname { get; init; } = player.NickName;
    public int Rank { get; init; } = player.Rank;
    public int LevelsCompleted { get; init; } = player.LevelsCompleted;
    public int Experience { get; init; } = player.Experience;
    public int Crystals { get; init; } = player.Crystals;
    public int NormalBluePrint { get; init; } = player.NormalBluePrint;
    public int AdvancedBluePrint { get; init; } = player.AdvancedBluePrint;
    public int RareBluePrint { get; init; } = player.RareBluePrint;
    public int LegendaryBluePrint { get; init; } = player.LegendaryBluePrint;
    public int Gold { get; init; } = player.Gold;
    public int AsteroidsDestroyed { get; init; } = player.AsteroidsDestroyed;
    public int Wins { get; init; } = player.Wins;
    public int PlaceAtLeaderBoard { get; init; } = player.PlaceAtLeaderBoard;
    public int OpenLootBoxSlots { get; init; } = player.OpenLootBoxSlots;
    public int OpenGunSlots { get; init; } = player.OpenGunSlots;

    public LootBoxSlotInfo[] Slots { get; init; } = new LootBoxSlotInfo[4];
}