namespace API.Models;

public class GunType
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;

    public ICollection<PlayerGun> PlayerGuns { get; set; } = new List<PlayerGun>();
}