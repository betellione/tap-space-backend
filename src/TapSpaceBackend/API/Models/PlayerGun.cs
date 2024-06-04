namespace API.Models;

public class PlayerGun
{
    public int PlayerId { get; set; }
    public int GunTypeId { get; set; }
    public int Level { get; set; }
    public int SlotNumber { get; set; }
    
    public Player? Player { get; set; }
    public GunType? GunType { get; set; }
}