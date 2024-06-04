using API.Data.Models;

namespace API.Models;

public class PlayerGun
{
    public long PlayerId { get; set; }
    public int GunTypeId { get; set; }
    public int Level { get; set; }
    public int SlotNumber { get; set; }
    
    public Player? Player { get; set; }
    public GunType? GunType { get; set; }
}