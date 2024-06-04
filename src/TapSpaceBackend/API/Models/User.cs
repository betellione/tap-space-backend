namespace API.Models;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public int Level { get; set; }
    public long Experience { get; set; }
    public int AmountOfDestroyedAsteroid { get; set; }
    public int Crystals { get; set; }
    public int Gold { get; set; }
}