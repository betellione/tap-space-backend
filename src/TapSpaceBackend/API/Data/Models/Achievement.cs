namespace API.Models;

public class Achievement
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    
    public ICollection<PlayerAchievement> PlayerAchievements { get; set; } = new List<PlayerAchievement>();
}